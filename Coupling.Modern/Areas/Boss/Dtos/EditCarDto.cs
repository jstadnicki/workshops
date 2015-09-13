using System.ComponentModel.DataAnnotations;
using Coupling.Modern.Common;

namespace Coupling.Modern.Areas.Boss.Dtos
{
    public class EditCarDto
    {
        public EditCarDto()
        { }

        public EditCarDto(int id, string name, decimal price, CarType carType, string color)
        {
            Id = id;
            Name = name;
            Price = price;
            CarType = carType;
            Color = color;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "1", "1000000000")]
        public decimal Price { get; set; }

        public CarType CarType { get; set; }

        [Required]
        public string Color { get; set; }
    }
}