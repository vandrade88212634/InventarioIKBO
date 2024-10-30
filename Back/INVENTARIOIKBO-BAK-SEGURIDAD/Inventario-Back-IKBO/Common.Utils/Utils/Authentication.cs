using Common.Utils.Constant;
using Common.Utils.Dto;
using Common.Utils.RestServices.Interface;
using Common.Utils.Utils.Interface;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;


namespace Common.Utils.Utils
{
    [ExcludeFromCodeCoverage]
    public class Authentication : IAuthentication
    {
        #region Attributes

        public readonly IRestService restService;
        public readonly IConfiguration configuration;
        public readonly IUtils utils;

        #endregion Attributes

        public string TokenFromAzureFunction { get; set; }

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="restService"></param>
        /// <param name="cache"></param>
        public Authentication(IUtils utils, IRestService restService, IConfiguration configuration)
        {
            this.utils = utils;
            this.restService = restService;
            this.configuration = configuration;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// get token validate in cache and validate date expiration
        /// </summary>
        /// <param name="validateCache"></param>
        /// <returns></returns>
        public string GetToken()
        {
            TokenDto tokenDto;
            if (string.IsNullOrEmpty(this.TokenFromAzureFunction))
            {
                tokenDto = utils.GetDataInCache<TokenDto>(CacheKeys.TokenKey);
            }
            else
            {
                tokenDto = new TokenDto() { Access_token = this.TokenFromAzureFunction };
            }

            if (tokenDto == null || !ValidateExpirationToken(tokenDto.Access_token))
            {
                tokenDto = GetTokenSecurity();
                utils.SaveDataInCache(CacheKeys.TokenKey, tokenDto, "Default");
            }

            string sToken = tokenDto.Access_token.Contains("Bearer") ? tokenDto.Access_token : string.Format("Bearer {0}", tokenDto.Access_token);

            return sToken;
        }

        /// <summary>
        /// get token from security
        /// </summary>
        /// <returns></returns>
        public TokenDto GetTokenSecurity()
        {
            IConfiguration conf = configuration.GetSection("SecurityService");
            string url = conf.GetSection("Url").Value;
            string urlBase = url;
            IConfiguration listSection = conf.GetSection("Autenticacion");
            string listController = listSection.GetSection("Controller").Value;
            IConfiguration listParams = listSection.GetSection("Params");

            UserAuthenticationDto userAuthentication = new UserAuthenticationDto
            {
                Email = listParams.GetSection("User").Value,
                Password = listParams.GetSection("Password").Value
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();

            TokenDto token = restService.PostRestServiceAsync<TokenDto>(urlBase, listController, string.Empty, userAuthentication, headers).Result;

            return token;
        }

        /// <summary>
        /// validate date expiration token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateExpirationToken(string token)
        {
            bool validToken = true;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            token = token.ToString().Contains("Bearer") ? token.Replace("Bearer", string.Empty).Trim() : token;

            JwtSecurityToken securityToken = handler.ReadJwtToken(token);
            DateTime dateExpirationToken = securityToken.ValidTo;

            if (dateExpirationToken < DateTime.UtcNow)
            {
                validToken = false;
            }

            return validToken;
        }

        #endregion Methods
    }
}