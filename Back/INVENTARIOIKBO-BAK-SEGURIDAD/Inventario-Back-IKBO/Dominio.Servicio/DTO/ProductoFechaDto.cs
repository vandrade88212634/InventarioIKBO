using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class ProductoFechaDto
    {
        
        public int IdProductoFecha { get; set; }

       
        public int IdProducto { get; set; }

       
        public int Saldo { get; set; }

       
        public DateTime FechaVence { get; set; }
    }
}
