using Common.Utils.RestServices.Interface;
using Common.Utils.RestServices;
using Common.Utils.Utils.Interface;
using Common.Utils.Utils;
using Dominio.Servicio.Servicios.Interfaces;
using Dominio.Servicio.Servicios;
using Infraestructura.Core.Repository.Interface;
using Infraestructura.Core.Repository;
using Infraestructura.Core.UnitOfWork;
using Infraestructura.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Microsoft.Extensions.Caching.Memory;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dominio.Servicio.Dependency
{
    
    public static class DependencyInyection
    {

        
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services,
                IConfiguration configuration)
        {
          

       



            //Repository await UnitofWork parameter ctor explicit
            //services.AddScoped<IUnitOfWork, IUnitOfWork);
            //services.AddScoped<Utils, Utils>();
            //services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IInventarioIKBOServices, InventarioIKBOServices>();
           
            //services.AddScoped< IAuthService, AuthService>();
           // services.AddScoped<IHeaderClaims, HeaderClaims>();
            //services.AddScoped<IRestService, RestService>();

            services.AddScoped<MemoryCache, MemoryCache>();
            services.AddScoped<Utils, Utils>();
            services.AddScoped<UnitOfWork, UnitOfWork>();
           
            //services.AddScoped<UserManager<UsuariosDto>, UserManager<UsuariosDto>>();
            //services.AddScoped(SignInManager<UsuariosDto>, SignInManager<UsuariosDto>>();
            //services.AddScoped<IOptions<JwtSettings>, IOptions<JwtSettings>>();



            // Infrastructure

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IHeaderClaims, HeaderClaims>();
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<IAuthentication, Authentication>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBinnacle, Binnacle>();
          services.AddTransient<IInventarioIKBOServices, InventarioIKBOServices>();
          




            ////Utils
            //services.AddTransient<IUtils, Utils>();
            //services.AddTransient<IAuthentication, Authentication>();
          


            services.AddDbContext<Infraestructura.Core.Context.SQLServer.ContextSql>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSQLServer"),
                  providerOptions => providerOptions.EnableRetryOnFailure()));

            //Configurando JWT VAP
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                    Options => {
                        Options.TokenValidationParameters = new TokenValidationParameters
                        {

                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token"])),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });


            return services;
        }


        
        #region methods




        private static IConfigurationRoot GetConnection()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        #endregion

    }

}
