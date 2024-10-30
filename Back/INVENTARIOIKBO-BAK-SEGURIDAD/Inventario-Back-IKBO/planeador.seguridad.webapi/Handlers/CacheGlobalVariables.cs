using Common.Utils.Constant;
using Common.Utils.Dto;
using Common.Utils.Utils.Interface;
using Infraestructura.Core.Context.SQLServer;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace Ideam.Sirlab.WebApi.Handlers
{


    [ExcludeFromCodeCoverage]
    public class CacheGlobalVariables : IActionFilter
    {
        private readonly IHeaderClaims _headerClaims;
        private readonly IUtils _utils;
        private readonly ContextSql _context;

        public CacheGlobalVariables(IHeaderClaims headerClaims, IUtils utils, ContextSql context)
        {
            _headerClaims = headerClaims;
            _utils = utils;
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var SaveProcess = false;
            string microservicio = context.HttpContext.Request.Headers["microServiceNameId"];
            string navegabilidad = context.HttpContext.Request.Headers["IdNavegavilidad"];
            string localIp = context.HttpContext.Request.Headers["Ip"];
            string token = context.HttpContext.Request.Headers["Authorization"];
            string uniqueName = _headerClaims.GetClaimValue(token, ClaimToken.UniqueName);
            var tokenDto = new TokenDto()
            {
                Access_token = token.Replace("Bearer ", string.Empty)
            };

            // var binnacleSave = _context.ConfigurationParameterEntities.FirstOrDefault(x => x.ParameterName == Enums.BinnacleOptions.Process.GetDisplayName()).Value;
            //var result = Convert.ToInt32(binnacleSave);

            // if (Convert.ToBoolean(result))
            //{
            SaveProcess = true;
            // }

            _utils.SaveDataInCache(CacheKeys.TokenKey, tokenDto, "Default");
            _utils.SaveDataInCache(CacheKeys.UniqueName, uniqueName, "Default");
            _utils.SaveDataInCache(CacheKeys.Microservicio, microservicio, "Default");
            _utils.SaveDataInCache(CacheKeys.Navegabilidad, navegabilidad, "Default");
            _utils.SaveDataInCache(CacheKeys.Ip, localIp, "Default");
            _utils.SaveDataInCache(CacheKeys.SaveProcess, SaveProcess, "Default");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _utils.RemoveDataInCache(CacheKeys.UniqueName);
            _utils.RemoveDataInCache(CacheKeys.Microservicio);
            _utils.RemoveDataInCache(CacheKeys.Navegabilidad);
            _utils.RemoveDataInCache(CacheKeys.Ip);
            _utils.RemoveDataInCache(CacheKeys.SaveProcess);
            _utils.RemoveDataInCache(CacheKeys.TokenKey);
        }
    }
}