using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // added for ToListAsync
using System.Web;

namespace API.Controllers;

// ApiController and route defined in BaseApiController
public class UsersController : BaseApiController // inherit from a base we created instead of ControlerBase 
{
    private readonly DataContext _context; 

    public UsersController(DataContext context)
    {
        _context = context;
    }


    [AllowAnonymous] // can perform without need for token authorization
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {

        var users = await _context.Users.ToListAsync();

        return users;
    }


    [Authorize] // must provide token in
    [HttpGet("{id}")]
    
    public async Task <ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
