
namespace Lbum.Utils.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ICollectionExtension
    {
        /// <summary>
        /// Indica si una lista es diferente de nulo y tiene items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool HasItems<T>(this ICollection<T> lista) => lista != null && lista.Any();
    }
}
