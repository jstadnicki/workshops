namespace Coupling.Controllers
{
    using System.Linq;

    using Areas.Boss.Dtos;
    using Common;
    using DataModels;
    using Interfaces;

    public class CarApplicationService : ICarApplicationService
    {
        private readonly IUnit carRepository;

        public CarApplicationService(IUnit carRepository)
        {
            this.carRepository = carRepository;
        }

        public CarsViewModel GetCarsViewModel()
        {
            var carsFromUnit = carRepository.Cars.ToList();

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
                            CarType = dto.SelectedCarType,
                            Color = dto.Color,
                            Name = dto.Name,
                            Price = dto.Price
                        };

            carRepository.Add(c);
            carRepository.Save();
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
            if (CanSave(dto))
            {
                SaveNewCar(dto);
            }
            return OperationResult.Ok();
        }

        public EditCarViewModel GetEditCarViewModel(int carId)
        {
            var carToEdit = carRepository.Cars.Single(r => r.Id == carId);
            var viewmodel = new EditCarViewModel(carToEdit);
            return viewmodel;
        }

        public EditCarViewModel GetEditCarViewModel(EditCarDto carDto)
        {
            return new EditCarViewModel(carDto);
        }

        public OperationResult TryEditCar(EditCarDto cardto)
        {
            if (CanSave(cardto))
            {
                var dbCar = carRepository.Cars.First(x => x.Id == cardto.Id);
                dbCar.CarType = cardto.CarType;
                dbCar.Id = cardto.Id;
                dbCar.Color = cardto.Color;
                dbCar.Price = cardto.Price;
                dbCar.Name = cardto.Name;

                carRepository.Save();

                return OperationResult.Ok();
            }

            return OperationResult.Fail();
        }

        public OperationResult TryDeleteCar(int id)
        {
            carRepository.Remove(id);
            carRepository.Save();
            return OperationResult.Ok();
        }

        private static bool CanSave(EditCarDto dto)
        {
            return true;
        }

        public CarDetailsViewModel GetCarDetailsViewModel(int id)
        {
            var car = carRepository.Cars.Single(fcar => fcar.Id == id);
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