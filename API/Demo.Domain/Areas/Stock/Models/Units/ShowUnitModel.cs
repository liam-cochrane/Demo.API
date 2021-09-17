using Demo.Data.Objects;
using System;

namespace Demo.Domain.Areas.Stock.Models.Units
{
    public class ShowUnitModel
    {
        public long UnitId { get; set; }

        public string Name { get; set; }

        public double MultipleOfBaseUnit { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ShowUnitModel(Unit dbEntity)
        {
            UnitId = dbEntity.UnitId;
            Name = dbEntity.Name;
            MultipleOfBaseUnit = dbEntity.MultipleOfBaseUnit;
            CreatedDate = dbEntity.CreatedDate;
            ModifiedDate = dbEntity.ModifiedDate;
        }
    }
}
