using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

public static class ApplicationServiceExtentions
{
                                                    // if it takes IServiceCollection, it is extending its (builder.services;)capabilites
    public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration config)
    {
        // since builder.Serives IS IServiceCollection, replace builder.services with service


        service.AddControllers(); 

        service.AddDbContext<DataContext>(opt =>   // add DataContext as a DbContext service
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));  // configuring sqlite with the connection string of DefaultConnection                                                                                   // config added to development settings
        });

        service.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        service.AddScoped<ITokenService, TokenService>();

        return service;

    }
}
