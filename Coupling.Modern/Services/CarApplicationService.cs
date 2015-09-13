using System.Linq;
using System.Threading.Tasks;
using Coupling.Modern.Areas.Boss.Dtos;
using Coupling.Modern.Common;
using Coupling.Modern.Controllers;
using Coupling.Modern.DataModels;
using Coupling.Modern.Infrastructure;
using Coupling.Modern.Interfaces;
using Coupling.Modern.Repository;
using Coupling.Modern.ViewModels;

namespace Coupling.Modern.Services
{
    public class CarApplicationService : ICarApplicationService
    {
        private readonly Unit carRepository;

        public CarApplicationService(Unit carRepository)
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

        public async void SaveNewCar(CarDto dto)
        {
            var c = new Car
                        {
                            CarType = dto.SelectedCarType,
                            Color = dto.Color,
                            Name = dto.Name,
                            Price = dto.Price
                        };

            this.carRepository.Add(c);
            await carRepository.Save();
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
            var carToEdit = this.carRepository.Cars.Single(r => r.Id == carId);
            var viewmodel = new EditCarViewModel(carToEdit);
            return viewmodel;
        }

        public EditCarViewModel GetEditCarViewModel(EditCarDto carDto)
        {
            return new EditCarViewModel(carDto);
        }

        public async Task<OperationResult> TryEditCar(EditCarDto cardto)
        {
            if (this.CanSave(cardto))
            {
                var dbCar = this.carRepository.Cars.First(x => x.Id == cardto.Id);
                dbCar.CarType = cardto.CarType;
                dbCar.Id = cardto.Id;
                dbCar.Color = cardto.Color;
                dbCar.Price = cardto.Price;
                dbCar.Name = cardto.Name;

                await carRepository.Save();

                return OperationResult.Ok();
            }

            return OperationResult.Fail();
        }

        public async Task<OperationResult> TryDeleteCar(int id)
        {
            await carRepository.Remove(id);
            await carRepository.Save();
            return OperationResult.Ok();
        }

        private bool CanSave(EditCarDto dto)
        {
            return true;
        }

        public CarDetailsViewModel GetCarDetailsViewModel(int id)
        {
            var car = this.carRepository.Cars.Single(fcar => fcar.Id == id);
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