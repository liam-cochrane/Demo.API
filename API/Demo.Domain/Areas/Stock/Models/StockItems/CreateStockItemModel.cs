using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Areas.Stock.Models.StockItems
{
    public class CreateStockItemModel
    {
        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
