using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.StockItemUnits;
using System.Linq;

namespace Demo.Domain.Areas.Stock.Helpers
{
    public static class StockItemUnitHelpers
    {
        public static IQueryable<StockItemUnit> ApplySearch(this IQueryable<StockItemUnit> dbEntities, StockItemUnitSearchModel search)
        {
            if (search != null)
            {

            }

            return dbEntities;
        }
    }
}
