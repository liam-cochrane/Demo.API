using Demo.Data.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Areas.Stock.Models.StockItemUnits
{
    public class CreateStockItemUnitModel
    {
        [Required]
        public long StockItemId { get; set; }

        [Required]
        public long UnitId { get; set; }
    }
}
