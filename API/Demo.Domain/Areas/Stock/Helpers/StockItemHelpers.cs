using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.StockItems;
using System.Linq;

namespace Demo.Domain.Areas.Stock.Helpers
{
    public static class StockItemHelpers
    {
        public static IQueryable<StockItem> ApplySearch(this IQueryable<StockItem> dbEntities, StockItemSearchModel search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(' ');
                    foreach (var word in words)
                    {
                        dbEntities = dbEntities.Where(x => x.Description.ToUpper().Contains(word) || x.ItemCode.ToUpper().Contains(word));
                    }
                }
            }

            return dbEntities;
        }
    }
}
