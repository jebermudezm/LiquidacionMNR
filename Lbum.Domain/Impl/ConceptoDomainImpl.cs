

namespace Lbum.Domain.Impl
{
    using Lbum.Data.Models;
    using Lbum.Domain.Cont;
    using Lbum.Repository.Contrat;
    using System.Linq;

    public class ConceptoDomainImpl : IConceptoDomainCont
    {
        private readonly AppDbContext _context;
        private readonly IConceptoRepository _conceptoRepository;
        public ConceptoDomainImpl(AppDbContext context, IConceptoRepository conceptoRepository)
        {
            _context = context;
            _conceptoRepository = conceptoRepository;
        }
        public IQueryable<TblConcepto> ConsultarConcepto()
        {
            var conceptos = _conceptoRepository.GetAllQueryable();
            return conceptos;
        }
    }
}
