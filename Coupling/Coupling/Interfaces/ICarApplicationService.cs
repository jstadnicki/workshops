namespace Coupling.Interfaces
{
    using Coupling.Areas.Boss.Dtos;
    using Coupling.Controllers;

    public interface ICarApplicationService
    {
        CarsViewModel GetCarsViewModel();
        CarDetailsViewModel GetCarDetailsViewModel(int id);

        CreateCarViewModel GetCreateCarViewModel();
        CreateCarViewModel GetCreateCarViewModel(CarDto dto);

        OperationResult TrySaveNewCar(CarDto dto);

        EditCarViewModel GetEditCarViewModel(int carId);
        EditCarViewModel GetEditCarViewModel(EditCarDto carDto);

        OperationResult TryEditCar(EditCarDto cardto);

        OperationResult TryDeleteCar(int id);
    }
}