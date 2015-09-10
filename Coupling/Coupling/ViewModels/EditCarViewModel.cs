namespace Coupling.Controllers
{
    using Coupling.Areas.Boss.Dtos;
    using Coupling.DataModels;

    public class EditCarViewModel
    {
        public EditCarViewModel(Car carToEdit)
        {
            this.EditCarDto = new EditCarDto(carToEdit.Id, carToEdit.Name, carToEdit.Price, carToEdit.CarType, carToEdit.Color);
        }

        public EditCarViewModel(EditCarDto carToEdit)
        {
            this.EditCarDto = carToEdit;
        }

        public EditCarDto EditCarDto { get; set; }
    }
}