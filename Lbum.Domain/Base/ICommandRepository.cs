

namespace Lbum.Domain.Base
{
    using Lbum.Data.Base.Contrat;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ICommandRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Add a item list into repository
        /// </summary>
        /// <param name="items">Item list to add to repository</param>
        void AddRange(IList<TEntity> items);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity item);

        /// <summary>
        /// Delete a item collection
        /// </summary>
        /// <param name="where">Items to delete</param>
        void DeleteWhere(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Sets modified entity into the repository.
        /// When calling Commit() method in UnitOfWork
        /// these changes will be saved into the storage
        /// <remarks>
        /// Internally this method always calls Repository.Attach() and Context.SetChanges()
        /// </remarks>
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Modify(TEntity item);

        /// <summary>
        /// Sets modified entities into the repository.
        /// </summary>
        /// <param name="items">Items with changes</param>
        void ModifyRange(IList<TEntity> items);
    }
}
