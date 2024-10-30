namespace Infraestructura.Core.UnitOfWork.Interface
{
    using Infraestructura.Core.Repository;
    using Infraestructura.Entity.Entities;

    public interface IUnitOfWork
    {
        #region Repository


        Repository<EstadoEntity> EstadoRepository { get; }

       
        Repository<MvtoEntity> MvtoRepository { get; }

        Repository<ProductoEntity> ProductoRepository { get; }
        Repository<ProductoFechaEntity> ProductoFechaRepository { get; }
        Repository<TipoMvtoEntity> TipoMvtoRepository { get; }

      


        #endregion Repository

        int Save();

        //IEnumerable<T> ExecuteSqlStoreProcedure<T>(string storeProcedureName, Dictionary<string, object> parameters);

    }

}