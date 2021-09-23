using Demo.Domain.Areas.Core.Models;
using System.Linq;

namespace Demo.Domain.Areas.Core.Helpers
{
    public static class QueryExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PagingModel paging)
        {
            if (paging != null && paging.Page.HasValue && paging.PageSize.HasValue)
            {
                return query
                    .Skip((paging.Page.Value - 1) * paging.PageSize.Value)
                    .Take(paging.PageSize.Value);
            }
            else
            {
                return query;
            }
        }
    }
}
