using Common.Utils.JWT;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Ideam.Sirlab.WebApi.Handlers
{
    [ExcludeFromCodeCoverage]
    public static class JwtConfigurationHandler
    {
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfigurationSection jwtAppSettings)
        {
            JwtSetting appSettings = jwtAppSettings.Get<JwtSetting>();
            byte[] secretKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
               {
                   jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                       ValidIssuer = appSettings.Issuer,
                       ValidAudience = appSettings.Audience,
                   };
               });
        }
    }
}