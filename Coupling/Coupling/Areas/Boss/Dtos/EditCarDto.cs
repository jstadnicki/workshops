namespace Coupling.Areas.Boss.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using Coupling.Common;

    public class EditCarDto
    {
        public EditCarDto()
        { }

        public EditCarDto(int id, string name, decimal price, CarType carType, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.CarType = carType;
            this.Color = color;
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