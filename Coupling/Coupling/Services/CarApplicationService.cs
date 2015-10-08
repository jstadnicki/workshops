namespace Coupling.Controllers
{
    using System.Linq;

    using Coupling.Areas.Boss.Dtos;
    using Coupling.Areas.Boss.Services.Garage.Implementation;
    using Coupling.Common;
    using Coupling.DataModels;
    using Coupling.Interfaces;

    public class CarApplicationService : ICarApplicationService
    {
        private readonly IUnit _carRepository;

        public CarApplicationService(IUnit carRepository)
        {
            this._carRepository = carRepository;
        }

        public CarsViewModel GetCarsViewModel()
        {
            var carsFromUnit = this._carRepository.Cars.ToList();

            var viewModel = new CarsViewModel();

            foreach (var car in carsFromUnit)
            {
                viewModel.Cars.Add(
                    new CarViewModel
                        {
                            Id = car.Id,
                            CarType = car.CarType.ToString(),
                            Color = car.Color,
                            Name = car.Name,
                            Price = car.Price.ToString("C")
                        });
            }

            return viewModel;
        }

        public void SaveNewCar(CarDto dto)
        {
            var c = new Car
                        {
                            CarType = (CarType)dto.SelectedCarType,
                            Color = dto.Color,
                            Name = dto.Name,
                            Price = dto.Price
                        };

            this._carRepository.Add(c);
            this._carRepository.Save();
        }

        public bool CanSave(CarDto viewmodel)
        {
            return true;
        }

        public CreateCarViewModel GetCreateCarViewModel()
        {
            return new CreateCarViewModel();
        }

        public CreateCarViewModel GetCreateCarViewModel(CarDto dto)
        {
            return new CreateCarViewModel(dto);
        }

        public OperationResult TrySaveNewCar(CarDto dto)
        {
            if (this.CanSave(dto))
            {
                this.SaveNewCar(dto);
            }
            return OperationResult.Ok();
        }

        public EditCarViewModel GetEditCarViewModel(int carId)
        {
            var carToEdit = this._carRepository.Cars.Single(r => r.Id == carId);
            var viewmodel = new EditCarViewModel(carToEdit);
            return viewmodel;
        }

        public EditCarViewModel GetEditCarViewModel(EditCarDto carDto)
        {
            return new EditCarViewModel(carDto);
        }

        public OperationResult TryEditCar(EditCarDto cardto)
        {
            if (!this.CanSave(cardto))
            {
                return OperationResult.Fail(ApplicationErrors.TryEditCarFailed);
            }

            var dbCar = this._carRepository.Cars.First(x => x.Id == cardto.Id);
            dbCar.CarType = cardto.CarType;
            dbCar.Id = cardto.Id;
            dbCar.Color = cardto.Color;
            dbCar.Price = cardto.Price;
            dbCar.Name = cardto.Name;

            this._carRepository.Save();

            return OperationResult.Ok();
        }

        public OperationResult TryDeleteCar(int id)
        {
            this._carRepository.Remove(id);
            this._carRepository.Save();
            return OperationResult.Ok();
        }

        private bool CanSave(EditCarDto dto)
        {
            return true;
        }

        public CarDetailsViewModel GetCarDetailsViewModel(int id)
        {
            var car = this._carRepository.Cars.Single(fcar => fcar.Id == id);
            var carDetailsViewModel = new CarDetailsViewModel(
                car.Name,
                car.Price.ToString("C"),
                car.CarType.ToString(),
                car.Color,
                car.Id);
            return carDetailsViewModel;
        }
    }
}