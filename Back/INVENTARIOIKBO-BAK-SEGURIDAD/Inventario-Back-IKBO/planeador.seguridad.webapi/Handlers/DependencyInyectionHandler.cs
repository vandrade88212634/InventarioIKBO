using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;
using Common.Utils.Utils;
using Common.Utils.Utils.Interface;
using Dominio.Servicio.Servicios;
using Dominio.Servicio.Servicios.Interfaces;
using Infraestructura.Core.Repository;
using Infraestructura.Core.Repository.Interface;
using Infraestructura.Core.UnitOfWork;
using Infraestructura.Core.UnitOfWork.Interface;

using System.Diagnostics.CodeAnalysis;

namespace Ideam.Sirlab.WebApi.Handlers
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            #region Register (dependency injection)

            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();
            services.AddScoped<InventarioIKBOServices, InventarioIKBOServices>();



            // Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<InventarioIKBOServices, InventarioIKBOServices>();


            // Common
            services.AddTransient<IHeaderClaims, HeaderClaims>();
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IBinnacle, Binnacle>();


            //Utils
            services.AddTransient<IUtils, Utils>();
     
            services.AddTransient<IAuthentication, Authentication>();
           
            #endregion Register (dependency injection)
        }
    }
}