using Demo.Data.Objects;
using System;

namespace Demo.Domain.Areas.Stock.Models.StockItemUnits
{
    public class ShowStockItemUnitModel
    {
        public long StockItemUnitId { get; set; }

        public long StockItemId { get; set; }

        public long UnitId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ShowStockItemUnitModel(StockItemUnit dbEntity)
        {
            StockItemUnitId = dbEntity.StockItemUnitId;
            StockItemId = dbEntity.StockItem.StockItemId;
            UnitId = dbEntity.Unit.UnitId;
            CreatedDate = dbEntity.CreatedDate;
            ModifiedDate = dbEntity.ModifiedDate.GetValueOrDefault();
        }
    }
}
