using Demo.Data.Objects;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Areas.Stock.Models.StockItemUnits
{
    public class UpdateStockItemUnitModel
    {
        [Required]
        public long StockItemId { get; set; }

        [Required]
        public long UnitId { get; set; }

        public UpdateStockItemUnitModel(StockItemUnit dbEntity)
        {
            StockItemId = dbEntity.StockItem.StockItemId;
            UnitId = dbEntity.Unit.UnitId;
        }
    }
}
