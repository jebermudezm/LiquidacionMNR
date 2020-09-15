namespace Lbum.Data.Base.Contrat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Base interface for implement a "Repository Pattern"
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <typeparam name="TEntity">Type of entity for this repository</typeparam>
    public interface IReadRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get all elements of type {TEntity} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get  elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

        #region Queryable

        /// <summary>
        /// Get elements of type {TEntity} in repository
        /// </summary>
        /// <returns>Selected items</returns>
        IQueryable<TEntity> GetAllQueryable(params string[] include);

        /// <summary>
        /// Get elements of type {TEntity} in repository
        /// </summary>
        /// <returns>Selected items</returns>
        IQueryable<TEntity> GetFilteredElementsQueryable(Expression<Func<TEntity, bool>> filter, params string[] include);

        #endregion Queryable
    }
}
