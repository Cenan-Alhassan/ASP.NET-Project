using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController // (DataContext context) to replace in-body declaration
    {

        [HttpPost("register")] // at ...api/acount/register (BaseApiController gives ...api/{controller})
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {   

            if (await UserExists(registerDto.Username)) return BadRequest("Username Already taken");


            using var hmac = new HMACSHA512(); // use to create hashes


            var newUser = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)), // convert password to bytes[], output bytes[]
                PasswordSalt = hmac.Key
            };


            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return newUser;

            
        }

        [HttpPost("login")]
        // function creates user field, checks if username is available using context 
        //-> takes available user if yes, unauthorized if null
        // create a hmac using the salt
        // compare to a hash created using this hmac
        // unauthorized if each byte in array does not match, return user if matches
        public async Task<ActionResult<UsernameTokenDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => 
            x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Username does not exist");


            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Incorrect password");
            }


             return new UsernameTokenDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username) // check if user already exists
        {
            // by comparing the lower of the inputted username and DB usernames
            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }

    }
}