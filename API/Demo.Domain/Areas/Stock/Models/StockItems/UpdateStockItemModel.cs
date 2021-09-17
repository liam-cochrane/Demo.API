using Demo.Data.Objects;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Areas.Stock.Models.StockItems
{
    public class UpdateStockItemModel
    {
        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string Description { get; set; }

        public UpdateStockItemModel(StockItem dbEntity)
        {
            ItemCode = dbEntity.ItemCode;
            Description = dbEntity.Description;
        }
    }
}
