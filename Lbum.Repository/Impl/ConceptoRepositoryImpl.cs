

namespace Lbum.Repository.Impl
{
    using Lbum.Data.Base;
    using Lbum.Data.Base.Contrat;
    using Lbum.Data.Models;
    using Lbum.Repository.Contrat;
    /// <summary>
    ///<see cref="IConceptopRepository"/>
    /// </summary>
    public class ConceptoRepositoryImpl : CommandRepository<TblConcepto>, IConceptoRepository
    {
        /// <summary>
        /// constructor MonedaRepository
        /// </summary>
        /// <param name="contextUnitOfWork"></param>
        public ConceptoRepositoryImpl(IContextUnitOfWork contextUnitOfWork)
            : base(contextUnitOfWork) { }
    }
}
