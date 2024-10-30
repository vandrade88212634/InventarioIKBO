using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ExceptionLogDto
    {
        #region Properties

        public string IdMicroservicio { get; set; }
        public string IdNavegabilidad { get; set; }
        public string DireccionIp { get; set; }
        public string NombreComponente { get; set; }
        public string Descripcion { get; set; }

        #endregion Properties
    }
}