namespace Common.Utils.Utils.Interface
{
    public interface IHeaderClaims
    {
        /// <summary>
        /// Method to get value claim from JwtToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        string GetClaimValue(string token, string claim);
    }
}