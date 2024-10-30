using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public  class TipoMvoDto
    {
        public int IdTipoMvto { get; set; }

       
        public string Nombre { get; set; }


       
        public string Signo { get; set; }
    }
}
