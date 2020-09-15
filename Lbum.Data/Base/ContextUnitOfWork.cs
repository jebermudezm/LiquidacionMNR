

namespace Lbum.Data.Base
{
    using Lbum.Data.Base.Contrat;
    using Lbum.Data.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    public class ContextUnitOfWork : DbContext, IContextUnitOfWork
    {
        private AppDbContext _context;

        public ContextUnitOfWork()
        {
#pragma warning disable S1481 // Force to Include Sql server dll.
            var unused = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
#pragma warning restore S1481 // Force to Include Sql server dll.
        }

        public ContextUnitOfWork(AppDbContext context)
        {
            _context = context;
        }



        #region IContextUnitOfWork Members

        /// <inheritdoc />
        /// <summary>
        /// <see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.CreateSet``1" />
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <returns></returns>
        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class => Set<TEntity>();

        /// <inheritdoc />
        /// <summary>
        /// <see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.Attach``1(``0)" />
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <param name="item"><see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.Attach``1(``0)" /></param>
        public virtual void Attach<TEntity>(TEntity item) where TEntity : class
        {
            Entry(item).State = EntityState.Unchanged;
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.SetModified``1(``0)" />
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <param name="item"><see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.SetModified``1(``0)" /></param>
        public virtual void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            try
            {
                EntityState entityState = Entry(item).State;

                if (entityState == EntityState.Detached)
                {
                    object id = item.GetType().GetProperty("Id")?.GetValue(item);
                    ApplyCurrentValues(Set<TEntity>().Find(id), item);
                    Entry(Set<TEntity>().Find(id));
                }
                else
                {
                    Entry(item).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepción no controlada en el método SetModified de ContextUnitOfWork", ex);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.ApplyCurrentValues``1(``0,``0)" />
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <param name="original"><see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.ApplyCurrentValues``1(``0,``0)" /></param>
        /// <param name="current"><see cref="M:AesChivor.Caos.Data.Base.Interfaces.IContextUnitOfWork.ApplyCurrentValues``1(``0,``0)" /></param>
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class =>
            Entry(original).CurrentValues.SetValues(current);

        #endregion IContextUnitOfWork Members

        #region IUnitOfWork Members

        /// <inheritdoc />
        ///  <summary>
        ///  Commit all changes made in  a container.
        ///  </summary>
        /// <remarks>
        ///  If entity have fixed properties and optimistic concurrency problem exists
        ///  exception is thrown
        /// </remarks>
        public int Commit() => SaveChanges();

        /// <summary>
        /// <see cref=""/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> ExecWithStoreProcedure<TEntity>(string query, params object[] parameters) => Database.SqlQuery<TEntity>(query, parameters);

        #endregion IUnitOfWork Members
    }
}
