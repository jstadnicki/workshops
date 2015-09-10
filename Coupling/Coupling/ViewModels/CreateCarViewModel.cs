namespace Coupling.Controllers
{
    using Coupling.Areas.Boss.Dtos;

    public class CreateCarViewModel
    {
        public CarDto CarDto { get; private set; }

        public CreateCarViewModel()
        {
            this.CarDto = new CarDto();
        }

        public CreateCarViewModel(CarDto dto)
            : this()
        {
            this.CarDto = dto;
        }
    }
}