using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class MvtoDto
    {
       
        public int IdMvto { get; set; }

        public DateTime Fecha { get; set; }


        public int IdProductoFecha { get; set; }
        public int IdProducto { get; set; }


        public int IdTipoMvto { get; set; }

       
        public int Cantidad { get; set; }

        public string NombreProducto { get; set; }
        public DateTime Fechavence { get; set; }
        public string  NombreTipoMvto { get; set; }

        public bool IsSucess { get; set; }
        public string Message { get; set; }


    }
}
