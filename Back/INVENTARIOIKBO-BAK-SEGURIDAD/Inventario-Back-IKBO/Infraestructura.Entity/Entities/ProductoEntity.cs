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
    [Table("Producto", Schema = "dbo")]
    public  class ProductoEntity
    {
        [Key]
        [Column("IdProducto", TypeName = "int")]
        public int IdProducto { get; set; }

        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }


    }
}
