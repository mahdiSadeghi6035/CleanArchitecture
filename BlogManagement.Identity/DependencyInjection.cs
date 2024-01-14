using BlogManagement.Application.Contracts.Identities;
using BlogManagement.Application.Model;
using BlogManagement.Identity.Context;
using BlogManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogManagement.Identity;

public static class DependencyInjection
{

    public static void AddIdentity(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JWTSettingModel>(configuration.GetSection("Authentication"));

        string connection = configuration.GetConnectionString("BlogDb");

        services.AddDbContext<UserContext>(x => x.UseSqlServer(connection));

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddIdentity<IdentityUser, IdentityRole>(option =>
        {
             option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-123456789";
             option.User.RequireUniqueEmail = true;
             option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
             option.Lockout.MaxFailedAccessAttempts = 3;
             option.Password.RequireDigit = true;
             option.Password.RequireLowercase = false;
             option.Password.RequireNonAlphanumeric = false;
             option.Password.RequiredLength = 8;
             option.Password.RequireUppercase = false;
             option.Password.RequiredUniqueChars = 0;
        })
        .AddEntityFrameworkStores<UserContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Authentication:Issuer"],
                ValidAudience = configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(configuration["Authentication:SecretKey"]))
            };
        });
    }
}
