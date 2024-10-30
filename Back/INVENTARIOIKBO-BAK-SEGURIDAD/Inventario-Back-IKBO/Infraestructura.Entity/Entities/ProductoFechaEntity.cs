using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("ProductoFecha", Schema = "dbo")]
    public  class ProductoFechaEntity
    {

        [Key]
        [Column("IdProductoFecha", TypeName = "int")]
        public int IdProductoFecha { get; set; }

        [Column("IdProducto", TypeName = "int")]
        public int IdProducto { get; set; }

        [Column("Saldo", TypeName = "int")]
        public int Saldo { get; set; }

        [Column("FechaVence", TypeName = "Datetime2")]
        public DateTime FechaVence { get; set; }

    }
}
