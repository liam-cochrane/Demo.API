using Demo.Data.Objects;
using System;

namespace Demo.Domain.Areas.Stock.Models.StockItems
{
    public class ShowStockItemModel
    {
        public long StockItemId { get; set; }

        public string ItemCode { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ShowStockItemModel(StockItem dbEntity)
        {
            StockItemId = dbEntity.StockItemId;
            ItemCode = dbEntity.ItemCode;
            Description = dbEntity.Description;
            CreatedDate = dbEntity.CreatedDate;
            ModifiedDate = dbEntity.ModifiedDate.GetValueOrDefault();
        }
    }
}
