using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class UserAuthenticationDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}