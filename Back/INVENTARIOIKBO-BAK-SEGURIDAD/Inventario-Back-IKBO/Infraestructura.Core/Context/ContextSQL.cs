namespace Infraestructura.Core.Context.SQLServer
{
    using Infraestructura.Entity.Entities;
    using Microsoft.EntityFrameworkCore;

    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ContextSql : DbContext
    {
        public ContextSql(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {
        }

        #region DbSet Entities





       public DbSet<EstadoEntity> EstadoEntity { get; set; }
       
        public DbSet<MvtoEntity> MvtoEntity { get; set; }
    
        public DbSet<ProductoEntity> ProductoEntity { get; set; }

        public DbSet<ProductoFechaEntity> ProductoFechaEntity { get; set; }
        public DbSet<TipoMvtoEntity> TipoMvtoEntity { get; set; }


        #endregion DbSet Entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





        }
    }
}