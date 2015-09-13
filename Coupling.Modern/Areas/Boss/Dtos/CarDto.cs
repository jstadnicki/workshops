using System.ComponentModel.DataAnnotations;
using Coupling.Modern.Common;

namespace Coupling.Modern.Areas.Boss.Dtos
{
    public class CarDto
    {
        public CarDto()
        {
        }

        public CarType SelectedCarType { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "1", "1000000000")]
        public decimal Price { get; set; }
    }
}