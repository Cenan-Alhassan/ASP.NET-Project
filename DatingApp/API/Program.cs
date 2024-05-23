using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>   // add DataContext as a DbContext service
{

    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));  // configuring sqlite with the connection string of DefaultConnection
                                                                                    // config added to development settings
});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
