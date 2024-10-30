using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public  class ProductoDto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public bool IsSucess {  get; set; }
        public string Message { get; set; }

    }
}
