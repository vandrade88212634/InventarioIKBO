using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("Mvto", Schema = "dbo")]
    public class MvtoEntity
    {
        [Key]
        [Column("IdMvto", TypeName = "int")]
        public int IdMvto { get; set; }

        [Column("Fecha", TypeName = "Datetime2")]
        public DateTime Fecha { get; set; }


        [Column("IdProductoFecha", TypeName = "int")]
        public int IdProductoFecha { get; set; }

        [Column("IdTipoMvto", TypeName = "int")]
        public int IdTipoMvto { get; set; }

        [Column("Cantidad", TypeName = "int")]
        public int Cantidad { get; set; }



    }
}
