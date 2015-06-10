using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Coupling.Controllers
{
    using System;

    using WebGrease.Css.Extensions;

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

        public ActionResult CreateCar()
        {
            var viewModel = _applicationService.GetCreateCarViewModel();
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult CreateCar(CarDto dto)
        {
            if (_applicationService.CanSave(dto,ModelState))
            {
                _applicationService.SaveNewCar(dto);
                return RedirectToAction("List");
            }

            var viewModel = _applicationService.GetCreateCarViewModel(dto);
            return View(viewModel);
        }

        public ActionResult Edit(int carId)
        {
            var db = new Unit();
            var carToEdit = db.Cars.FirstOrDefault(r => r.Id == carId);
            if (carToEdit == null)
            {
                return new HttpNotFoundResult("nie ma samochodu z takim id");
            }

            var x = new Dictionary<int, string>();
            x[1] = "Fiat";
            x[2] = "Form";
            x[3] = "Volksvagen";
            x[3] = "Mazda";
            x[4] = "Luxus";
            x[5] = "Kiya";



            ViewData["ctypes"] = x;
            return View("UpdateCarView", carToEdit);

        }

        public ActionResult UpdateCarData(Car c, int newSelectedCarType)
        {
            if (ModelState.IsValid)
            {
                using (var d = new Unit())
                {
                    d.Cars.First(x => x.Id == c.Id).CarType = (CarType)newSelectedCarType;
                    d.Cars.First(x => x.Id == c.Id).Id = c.Id;
                    d.Cars.First(x => x.Id == c.Id).Color = c.Color;
                    d.Cars.First(x => x.Id == c.Id).Price = c.Price;
                    d.Cars.First(x => x.Id == c.Id).Name = c.Name;

                    d.SaveChanges();

                    return RedirectToAction("List");
                }
            }
            else
            {
                return RedirectToAction("Edit", "Car", new { carId = c.Id });
            }
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
        private readonly CarDto _carDto;

        public Dictionary<int, string> CarTypes { get; set; }
        

        public CarDto CarDto
        {
            get
            {
                return _carDto;
            }
        }

        public int SelectedCarType { get; set; }

        public CreateCarViewModel()
        {
            var x = new Dictionary<int, string>();
            Enum.GetValues(typeof(CarType))
                .Cast<CarType>()
                .ForEach(a => x.Add((int)a, a.ToString()));

            CarTypes = x;
            _carDto = new CarDto();
        }

        public CreateCarViewModel(CarDto dto):this()
        {
            _carDto = dto;
        }
    }

    public class Unit : DbContext,IUnit
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
        void SaveNewCar(CarDto dto);

        bool CanSave(CarDto viewmodel, ModelStateDictionary modelState);
        
        CreateCarViewModel GetCreateCarViewModel();
        CreateCarViewModel GetCreateCarViewModel(CarDto dto);
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

        public bool CanSave(CarDto viewmodel, ModelStateDictionary modelState)
        {
            return modelState.IsValid;
        }

        public CreateCarViewModel GetCreateCarViewModel()
        {
            return new CreateCarViewModel();
        }

        public CreateCarViewModel GetCreateCarViewModel(CarDto dto)
        {
            return new CreateCarViewModel(dto);
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
}