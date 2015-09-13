using Coupling.Modern.Areas.Boss.Dtos;
using Coupling.Modern.DataModels;

namespace Coupling.Modern.ViewModels
{
    public class EditCarViewModel
    {
        public EditCarViewModel(Car carToEdit)
        {
            EditCarDto = new EditCarDto(carToEdit.Id, carToEdit.Name, carToEdit.Price, carToEdit.CarType, carToEdit.Color);
        }

        public EditCarViewModel(EditCarDto carToEdit)
        {
            EditCarDto = carToEdit;
        }

        public EditCarDto EditCarDto { get; set; }
    }
}