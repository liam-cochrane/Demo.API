using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Objects
{
    public class StockItemUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StockItemUnitId { get; set; }

        public StockItem StockItem { get; set; }

        public Unit Unit { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }

        public StockItemUnit() { }
    }
}
