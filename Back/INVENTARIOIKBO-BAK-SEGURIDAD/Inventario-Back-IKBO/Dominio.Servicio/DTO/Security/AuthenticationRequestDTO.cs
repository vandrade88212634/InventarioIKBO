using System.Diagnostics.CodeAnalysis;

namespace Dominio.Servicio.DTO.Security
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationRequestDto
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int validacion { get; set; }
    }
}