using System.Collections.Generic;
using System.Linq;

namespace CardDetails.API.Commons.Extensions
{
    public static class PaginationExtension
    {
        public static Dictionary<TKey, TValue> Paginate<TKey, TValue>(this Dictionary<TKey, TValue> items, int pageNumber, int pageSize)
        {
            return items.Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize).ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
