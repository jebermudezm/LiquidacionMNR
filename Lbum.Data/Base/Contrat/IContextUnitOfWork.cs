

namespace Lbum.Data.Base.Contrat
{
    using System.Collections.Generic;
    using System.Data.Entity;

    public interface IContextUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Create a object set for a type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <returns>Object set of type {TEntity}</returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// Attach object in the "ObjectStateManager"
        /// </summary>
        /// <param name="item">item to attach</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Set the modify element.
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <param name="item">item to attach</param>
        void SetModified<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Applies the values ​​in the <paramref name="original"/>
        /// Apply
        /// </summary>
        /// <typeparam name="TEntity">Type of element in object set</typeparam>
        /// <param name="original">Original entity</param>
        /// <param name="current">current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

        /// <summary>
        /// Execute Store Procedure
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecWithStoreProcedure<TEntity>(string query, params object[] parameters);
    }
}
