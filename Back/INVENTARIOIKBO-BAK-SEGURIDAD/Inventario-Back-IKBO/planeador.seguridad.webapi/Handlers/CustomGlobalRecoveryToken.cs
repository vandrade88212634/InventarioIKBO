using Common.Utils.Constant;
using Common.Utils.Dto;
using Common.Utils.Utils.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
namespace Ideam.Sirlab.WebApi.Handlers
{
    [ExcludeFromCodeCoverage]
    public class CustomGlobalRecoveryToken : IActionFilter
    {
        private readonly IHeaderClaims _headerClaims;
        private readonly IUtils _utils;
        private readonly IAuthentication Authentication;

        public CustomGlobalRecoveryToken(IHeaderClaims headerClaims, IUtils utils, IAuthentication authentication)
        {
            _headerClaims = headerClaims;
            _utils = utils;
            this.Authentication = authentication;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

            string token = this.Authentication.GetToken();
            string uniqueName = _headerClaims.GetClaimValue(token, ClaimToken.UniqueName);
            var tokenDto = new TokenDto()
            {
                Access_token = token
            };

            _utils.SaveDataInCache(CacheKeys.TokenKey, tokenDto, "Default");
            _utils.SaveDataInCache(CacheKeys.UniqueName, uniqueName, "Default");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _utils.RemoveDataInCache(CacheKeys.UniqueName);
        }
    }
}
