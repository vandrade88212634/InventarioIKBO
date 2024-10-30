using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("Estado", Schema = "dbo")]
    public class EstadoEntity
    {
        [Key]
        [Column("IdEstado", TypeName = "int")]
        public int IdTipoMvto { get; set; }

        [Column("Nombre", TypeName = "varchar(50)")]
        public string Descripcion { get; set; }


        [Column("DiasDesde", TypeName = "int")]
        public int DiasDesde { get; set; }

        [Column("DiasHasta", TypeName = "int")]
        public int DiasHasta { get; set; }

    }
}
