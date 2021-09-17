using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Areas.Stock.Models.Units
{
    public class CreateUnitModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Multiple must be greater than 0")]
        public double MultipleOfBaseUnit { get; set; }
    }
}
