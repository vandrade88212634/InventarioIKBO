using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("TipoMvto", Schema = "dbo")]
    public class TipoMvtoEntity
    {
        [Key]
        [Column("IdTipoMvto", TypeName = "int")]
        public int IdTipoMvto { get; set; }

        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }


        [Column("Signo", TypeName = "varchar(1)")]
        public string Signo { get; set; }




    }
}
