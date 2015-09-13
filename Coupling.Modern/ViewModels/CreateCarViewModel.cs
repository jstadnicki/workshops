using Coupling.Modern.Areas.Boss.Dtos;

namespace Coupling.Modern.ViewModels
{
    public class CreateCarViewModel
    {
        public CarDto CarDto { get; private set; }

        public CreateCarViewModel()
        {
            CarDto = new CarDto();
        }

        public CreateCarViewModel(CarDto dto)
            : this()
        {
            CarDto = dto;
        }
    }
}