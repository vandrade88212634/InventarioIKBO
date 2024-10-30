using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ideam.Sirlab.WebApi.Models.Users
{
    [ExcludeFromCodeCoverage]
    public class CambiarImagenModel
    {
        public string? CorreoElectronico { get; set; } = string.Empty;
        public string? ImagenBase64 { get; set; } = string.Empty;
    }
}
