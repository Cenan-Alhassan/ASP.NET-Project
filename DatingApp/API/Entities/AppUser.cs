using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities;

public class AppUser
{
    public int Id {get; set;}   
    public required string UserName {get; set;} // "required" means that a database entry cannot be created without it

    public required byte[] PasswordHash {get; set;}

    public required byte[] PasswordSalt {get; set;}

    
}
