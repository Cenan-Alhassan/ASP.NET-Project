
using API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration); // self made extension method
builder.Services.AddIdentityServices(builder.Configuration); // self made extension method

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseCors(); // order of middleware is important

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
