using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Timesheets.Presentation.Settings;

namespace Timesheets.Presentation.Extensions;

internal static class JWTExtension
{
    public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration[$"{nameof(JWTSetting)}:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration[$"{nameof(JWTSetting)}:Audience"],
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[$"{nameof(JWTSetting)}:Key"])),
                    ValidateIssuerSigningKey = true,
                });

        return services;
    }
}