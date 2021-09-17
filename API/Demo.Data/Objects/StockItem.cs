using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Objects
{
    public class StockItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StockItemId { get; set; }

        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }

        public ICollection<StockItemUnit> StockItemUnits { get; set; }

        public StockItem() { }
    }
}
