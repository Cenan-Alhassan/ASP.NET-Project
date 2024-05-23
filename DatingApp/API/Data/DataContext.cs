using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data; // must elaborate on namspace from simply "API"

public class DataContext : DbContext    // a derived class from Dbcontext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users {get; set;}    // a property of Dbset type with AppUser as entity, properties of AppUser will become columns
}
