namespace Coupling.Controllers
{
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