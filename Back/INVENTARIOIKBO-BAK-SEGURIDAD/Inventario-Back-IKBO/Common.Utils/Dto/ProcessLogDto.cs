using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    [ExcludeFromCodeCoverage]
    public class ProcessLogDto
    {
        public string IdMicroservicio { get; set; }
        public string IdNavegabilidad { get; set; }
        public string DireccionIp { get; set; }
        public string Modulo { get; set; }
        public string Opcion { get; set; }
        public string Subopcion { get; set; }
        public string Agente { get; set; }
        public string descripcionVariable { get; set; }

    }
}