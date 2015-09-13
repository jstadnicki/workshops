using System.Threading.Tasks;
using Coupling.Modern.Areas.Boss.Dtos;
using Coupling.Modern.Infrastructure;
using Coupling.Modern.ViewModels;

namespace Coupling.Modern.Interfaces
{
    public interface ICarApplicationService
    {
        CarsViewModel GetCarsViewModel();
        CarDetailsViewModel GetCarDetailsViewModel(int id);

        CreateCarViewModel GetCreateCarViewModel();
        CreateCarViewModel GetCreateCarViewModel(CarDto dto);

        OperationResult TrySaveNewCar(CarDto dto);

        EditCarViewModel GetEditCarViewModel(int carId);
        EditCarViewModel GetEditCarViewModel(EditCarDto carDto);

        Task<OperationResult> TryEditCar(EditCarDto cardto);

        Task<OperationResult> TryDeleteCar(int id);
    }
}