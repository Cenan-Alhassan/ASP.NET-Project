using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities;

public class AppUser
{
    public int Id {get; set;}   // entityframework knows "Id" is the primary key by convention
    public string UserName {get; set;}

    
}
