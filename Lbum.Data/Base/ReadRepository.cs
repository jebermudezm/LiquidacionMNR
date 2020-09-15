
namespace Lbum.Data.Base
{
    using Lbum.Data.Base.Contrat;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <inheritdoc />
    /// <summary>
    /// Repository Base
    /// Default base class for repostories. This generic repository
    /// is a default implementation of <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
    /// and your specific repositories can inherit from this base class so automatically will get default implementation.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repostory</typeparam>
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        private readonly IContextUnitOfWork _unitOfWork;

        #region Constructor

        /// <summary>
        /// Create a new instance of Repository
        /// </summary>
        /// <param name="unitOfWork">A unit of work for this repository</param>
        public ReadRepository(IContextUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dbSet = _unitOfWork.CreateSet<TEntity>();
        }

        #endregion Constructor

        #region IRepository<TEntity> Members

        /// <inheritdoc />
        /// <summary>
        /// Return a unit of work in this repository
        /// </summary>
        public IUnitOfWork UnitOfWork => _unitOfWork;

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
        /// </summary>
        /// <returns><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></returns>
        public IEnumerable<TEntity> GetAll() => _dbSet.AsEnumerable();

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
        /// </summary>
        /// <param name="filter"><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></param>
        /// <returns><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></returns>
        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return _dbSet.Where(filter).ToList();
        }

        #region Queryable

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
        /// </summary>
        /// <param name="include"><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllQueryable(params string[] include)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            return include.Aggregate(query, (current, item) => current.Include(item));
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
        /// </summary>
        /// <param name="filter"><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></param>
        /// <param name="include"><see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" /></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetFilteredElementsQueryable(Expression<Func<TEntity, bool>> filter,
            params string[] include)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            IQueryable<TEntity> query = _dbSet.Where(filter);

            return include.Aggregate(query, (current, item) => current.Include(item));
        }

        #endregion Queryable

        #endregion IRepository<TEntity> Members
    }
}