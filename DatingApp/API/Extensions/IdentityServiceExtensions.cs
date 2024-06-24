using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Entities;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection service, IConfiguration config)
    {

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {

        // use the same key configuration to decrypt as when creating the token since it is a symmetric key
        var tokenKey = config["TokenKey"] ?? throw new Exception("Token key not found in configuration");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,    // means that the issuer (client wanting http action) needs a signing key (token)
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),  // that key being a symmetric key which is tokeKey
            ValidateIssuer = false,
            ValidateAudience = false

        };

        });

        return service;
    }
}
