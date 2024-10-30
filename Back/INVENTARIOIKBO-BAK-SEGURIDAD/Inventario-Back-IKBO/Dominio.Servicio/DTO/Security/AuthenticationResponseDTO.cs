using System.Diagnostics.CodeAnalysis;

namespace Dominio.Servicio.DTO.Security
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationResponseDto
    {
        public string token { get; set; }
    }
}