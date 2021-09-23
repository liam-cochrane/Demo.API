using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.Units;
using System.Linq;

namespace Demo.Domain.Areas.Stock.Helpers
{
    public static class UnitHelpers
    {
        public static IQueryable<Unit> ApplySearch(this IQueryable<Unit> dbEntities, UnitSearchModel search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(' ');
                    foreach (var word in words)
                    {
                         dbEntities = dbEntities.Where(x => x.Name.ToUpper().Contains(word));
                    }
                }
                if (search.StockItemId.HasValue)
                {
                    dbEntities = dbEntities.Where(x => x.StockItemUnits.Any(y => y.StockItem.StockItemId == search.StockItemId));
                }
            }

            return dbEntities;
        }
    }
}
