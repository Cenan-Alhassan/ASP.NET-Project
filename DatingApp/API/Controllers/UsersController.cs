using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // added for ToListAsync
using System.Web;


namespace API.Controllers;


[ApiController]
[Route("api/[controller]")] // route will be named https://localhost:5001/api/Users


public class UsersController : ControllerBase
{
    private readonly DataContext _context;  // create outer private field and assign it the constructor parameter

    public UsersController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {

        var users = await _context.Users.ToListAsync();

        return users;
    }


    [HttpGet("{id}")]   
    
    public async Task <ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
