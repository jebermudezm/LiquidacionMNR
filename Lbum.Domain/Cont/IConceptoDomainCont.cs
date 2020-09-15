


namespace Lbum.Domain.Cont
{
    using Lbum.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Interfaz de regla de negocio modulo de Concepto
    /// </summary>
    public interface IConceptoDomainCont
    {
        /// <summary>
        /// Consultar la curva horaria agrupada mensualmente
        /// </summary>
        /// <param name="curva"></param>
        /// <returns></returns>
        IQueryable<TblConcepto> ConsultarConcepto();
    }
}
