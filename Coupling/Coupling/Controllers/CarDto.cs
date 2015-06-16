namespace Coupling.Controllers
{
    using System.ComponentModel.DataAnnotations;

    public class CarDto
    {
        public CarDto()
        {
        }

        public int SelectedCarType { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal),"1","1000000000")]
        public decimal Price { get; set; }
    }
}