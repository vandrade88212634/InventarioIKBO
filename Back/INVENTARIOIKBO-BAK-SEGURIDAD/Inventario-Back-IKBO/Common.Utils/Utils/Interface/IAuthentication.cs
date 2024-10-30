using Common.Utils.Dto;

namespace Common.Utils.Utils.Interface
{
    public interface IAuthentication
    {
        /// <summary>
        /// get token validate in cache and validate date expiration
        /// </summary>
        /// <param name="validateCache"></param>
        /// <returns></returns>
        string GetToken();

        /// <summary>
        /// get token from security
        /// </summary>
        /// <returns></returns>
        TokenDto GetTokenSecurity();

        /// <summary>
        /// validate date expiration token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateExpirationToken(string token);

        string TokenFromAzureFunction { get; set; }
    }
}