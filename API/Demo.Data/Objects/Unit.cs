using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Objects
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UnitId { get; set; }

        public string Name { get; set; }

        public double MultipleOfBaseUnit { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }

        public ICollection<StockItemUnit> StockItemUnits { get; set; }

        public Unit() { }
    }
}
