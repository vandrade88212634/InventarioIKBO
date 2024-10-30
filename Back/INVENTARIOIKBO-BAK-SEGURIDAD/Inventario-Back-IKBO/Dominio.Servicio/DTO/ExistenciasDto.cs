using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public  class ExistenciasDto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaVence { get; set; }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }

        public int saldo {  get; set; }

        public bool IsSucess { get; set; }
        public string Message { get; set; }

    }
}
