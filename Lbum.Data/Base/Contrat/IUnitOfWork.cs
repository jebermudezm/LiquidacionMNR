

namespace Lbum.Data.Base.Contrat
{
    using System;
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If entity have fixed properties and optimistic concurrency problem exists
        /// exception is thrown
        ///</remarks>
        int Commit();
    }
}
