using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>   // add DataContext as a DbContext service
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));  // configuring sqlite with the connection string of DefaultConnection                                                                                   // config added to development settings
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseCors(); // order of middleware is important

app.MapControllers();

app.Run();
