namespace Lbum.Data.Base
{
    using Lbum.Data.Base.Contrat;
    using Lbum.Data.Enum;
    using Lbum.Data.Models;
    using Lbum.Utils.Extensions;
    using Lbum.Utils.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;


    /// <inheritdoc cref="ICommandRepository{TEntity}" />
    /// <summary>
    /// Repository Base
    /// Default base class for repostories. This generic repository
    /// is a default implementation of <see cref="T:AesChivor.Caos.Domain.Base.IReadRepository`1" />
    /// and your specific repositories can inherit from this base class so automatically will get default implementation.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repostory</typeparam>
    public class CommandRepository<TEntity> : ReadRepository<TEntity>,
        ICommandRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        private readonly IContextUnitOfWork _unitOfWork;

        #region ICommandRepository<TEntity> Members

        public CommandRepository(IContextUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dbSet = _unitOfWork.CreateSet<TEntity>();
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="item"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            //CrearAuditoria(item, AccionesAuditoria.Crear);

            _dbSet.Add(item);
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="items"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void AddRange(IList<TEntity> items)
        {
            if (!items.HasItems())
            {
                throw new ArgumentNullException(nameof(items));
            }

            //foreach (TEntity item in items)
            //{
            //    CrearAuditoria(item, AccionesAuditoria.Crear);
            //}

            ((DbSet<TEntity>)_dbSet).AddRange(items);
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="where"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = _dbSet.Where(where).AsEnumerable();

            foreach (TEntity obj in objects)
            {
                //CrearAuditoria(obj, AccionesAuditoria.Eliminar);

                _dbSet.Remove(obj);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="item"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void Delete(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _unitOfWork.Attach(item);

            _dbSet.Remove(item);
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="item"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void Modify(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            //CrearAuditoria(item, AccionesAuditoria.Modificar);

            _unitOfWork.SetModified(item);
        }

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" />
        /// </summary>
        /// <param name="items"><see cref="T:AesChivor.Caos.Domain.Base.ICommandRepository`1" /></param>
        public virtual void ModifyRange(IList<TEntity> items)
        {
            if (!items.HasItems())
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (TEntity item in items)
            {
                //CrearAuditoria(item, AccionesAuditoria.Modificar);
                _unitOfWork.SetModified(item);
            }
        }

        #endregion ICommandRepository<TEntity> Members

        #region Privates Methods

        /// <summary>
        /// Serializar una entidad a un string con formato json.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected string SerializarEntidadJson(TEntity item) =>
            Serializer.SerializarObjetoJson(item);

        /// <summary>
        /// Crear objeto auditoria para registrarla en la base de datos.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="accion"></param>
        protected void CrearAuditoria(TEntity item, AccionesAuditoria accion)
        {
            bool aplicaAuditoria;

            try
            {
                aplicaAuditoria = Convert.ToBoolean(item.GetType().GetProperty("AplicaAuditoria").GetValue(item));
            }
            catch
            {
                aplicaAuditoria = false;
            }

            if (aplicaAuditoria)
            {
                string jsonContrato = SerializarEntidadJson(item);

                _unitOfWork.CreateSet<TblAuditoria>().Add(
                    new TblAuditoria
                    {
                        IdEntidad = Convert.ToInt64(item.GetType().GetProperty("Id").GetValue(item)),
                        Fecha = DateTime.Now,
                        Usuario = item.GetType().GetProperty("Usuario").GetValue(item) != null
                                        ? item.GetType().GetProperty("Usuario").GetValue(item).ToString()
                                        : "Usuario sin especificar",
                        IdAccion = (short)accion,
                        ObjetoEntidad = jsonContrato,
                        Observaciones = item.GetType().GetProperty("Observaciones").GetValue(item) != null
                                            ? item.GetType().GetProperty("Observaciones").GetValue(item).ToString()
                                            : string.Empty,
                        EntidadAuditoria = item.GetType().Name,
                    }
                );
            }
        }

        #endregion Privates Methods
    }
}
