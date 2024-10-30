using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    /// <summary>
    /// Class AuditLogDto.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AuditLogDto
    {
        #region Properties
        public string IdMicroservicio { get; set; }
        public string IdNavegabilidad { get; set; }
        public string DireccionIp { get; set; }
        public string Modulo { get; set; }
        public string Tabla { get; set; }
        public string TipoAccion { get; set; }
        public string AccionRealizada { get; set; }

        #endregion Properties
    }
}