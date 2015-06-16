using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Coupling.Controllers
{
    using System;

    public class CarController : Controller
    {
        private readonly ICarApplicationService _applicationService;

        public CarController(ICarApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public ActionResult List()
        {
            var viewModel = _applicationService.GetCarsViewModel();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _applicationService.GetCarDetailsViewModel(id);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = _applicationService.GetCreateCarViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CarDto cardto)
        {
            return Do(
                () => _applicationService.TrySaveNewCar(cardto),
                r => RedirectToAction("List"),
                r =>
                {
                    var viewModel = _applicationService.GetCreateCarViewModel(cardto);
                    return View(viewModel);
                });
        }

        private ActionResult Do<T>(
            Func<T> command,
            Func<T, ActionResult> onSuccess,
            Func<T, ActionResult> onFail)
            where T : OperationResult, new()
        {
            if (false == ModelState.IsValid)
            {
                return onFail(new T());
            }

            var result = command();

            if (!result.IsValid)
            {
                UpdateModelStateErrors(result.Errors);
                return onFail(result);
            }

            return onSuccess(result);
        }

        private void UpdateModelStateErrors(List<KeyValuePair<string, string>> result)
        {
            result.ForEach(x => ModelState.AddModelError(x.Key, x.Value));
        }

        public ActionResult Edit(int carId)
        {
            var viewModel = _applicationService.GetEditCarViewModel(carId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCarDto EditCarDto)
        {
            return Do(
                () => _applicationService.TryEditCar(EditCarDto),
                x => RedirectToAction("Details", new { id = EditCarDto.Id }),
                x =>
                {
                    var viewModel = _applicationService.GetEditCarViewModel(EditCarDto);
                    return View(viewModel);
                });
        }


        public ActionResult Delete(int id)
        {
            var x = new Unit();
            x.Cars.Remove(x.Cars.First(d => d.Id == id));
            x.SaveChanges();
            return RedirectToAction("List", "Car");
        }
    }

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

    public class Unit : DbContext, IUnit
    {
        public Unit()
            : base("DefaultConnection")
        {

        }
        public IDbSet<Car> Cars { get; set; }

        public void Save()
        {
            SaveChanges();
        }
    }

    public interface IUnit
    {
        IDbSet<Car> Cars { get; set; }

        void Save();
    }

    public class Car
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CarType CarType { get; set; }
    }

    public enum CarType : int
    {
        Fiat,
        Ford,
        VW,
        Mazda,
        Luxus,
        [Display(Description = "Kia")]
        Kya
    }

    public class CarsViewModel
    {
        public CarsViewModel()
        {
            Cars = new List<CarViewModel>();
        }

        public List<CarViewModel> Cars { get; set; }
    }

    public class CarViewModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string CarType { get; set; }
    }

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

    }

    public class EditCarDto
    {
        public EditCarDto()
        {}

        public EditCarDto(int id, string name, decimal price, CarType carType, string color)
        {
            Id = id;
            Name = name;
            Price = price;
            CarType = carType;
            Color = color;
        }

        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        [Range(typeof(decimal), "1", "1000000000")]
        public decimal Price { get; set; }
        
        public CarType CarType { get; set; }
       
        [Required]
        public string Color { get; set; }
    }

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

    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(string name, string price, string carType, string color, int id)
        {
            Name = name;
            Price = price;
            CarType = carType;
            Color = color;
            Id = id;
        }

        public string Name { get; set; }
        public string Price { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
    }

    public class CarApplicationService : ICarApplicationService
    {
        private readonly IUnit _unit;

        public CarApplicationService(IUnit unit)
        {
            _unit = unit;
        }

        public CarsViewModel GetCarsViewModel()
        {
            var carsFromUnit = _unit.Cars.ToList();

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

            _unit.Cars.Add(c);
            _unit.Save();
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
            return new OperationResult(true);
        }

        public EditCarViewModel GetEditCarViewModel(int carId)
        {
            var carToEdit = _unit.Cars.Single(r => r.Id == carId);
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
                var dbCar = _unit.Cars.First(x => x.Id == cardto.Id);
                dbCar.CarType = cardto.CarType;
                dbCar.Id = cardto.Id;
                dbCar.Color = cardto.Color;
                dbCar.Price = cardto.Price;
                dbCar.Name = cardto.Name;

                _unit.Save();

                return new OperationResult(true);
            }

            return new OperationResult(false);
        }

        private bool CanSave(EditCarDto dto)
        {
            return true;
        }

        public CarDetailsViewModel GetCarDetailsViewModel(int id)
        {
            var car = _unit.Cars.Single(fcar => fcar.Id == id);
            var carDetailsViewModel = new CarDetailsViewModel(
                car.Name,
                car.Price.ToString("C"),
                car.CarType.ToString(),
                car.Color,
                car.Id);
            return carDetailsViewModel;
        }
    }

    public class OperationResult
    {
        public OperationResult()
            : this(false)
        {
        }

        public OperationResult(bool isValid)
        {
            Errors = new List<KeyValuePair<string, string>>();
            IsValid = isValid;
        }

        public bool IsValid { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; set; }
    }
}