using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Coupling.Controllers
{
    public class CarController : Controller
    {
       public ActionResult List()
        {
            var db = new Unit();
            var c = db.Cars;

            return View(c);
        }

        public ActionResult Details(int id)
        {
            var c = new Unit().Cars.First(d => d.Id == id);
            return View(c);
        }

        public ActionResult New()
        {
            var viewModel = new NewCarViewModel();
            return View("CreateNewCarView",viewModel);
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
                    d.Cars.First(x => x.Id == c.Id).CarType = (CarType) newSelectedCarType;
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

        public ActionResult SaveNewCar(NewCarViewModel viewmodel)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("New");
            }

            var c =new Car
            {
                CarType = (CarType)viewmodel.SelectedCarType,
                Color = viewmodel.Color,
                Name = viewmodel.Name,
                Price = viewmodel.Price
            };

            var data = new  Unit();
            data.Cars.Add(c);
            data.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var x = new Unit();
            x.Cars.Remove(x.Cars.First(d => d.Id == id));
            x.SaveChanges();
            return RedirectToAction("List", "Car");
        }
    }

    public class NewCarViewModel
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, string> CarTypes { get; set; }
        public int SelectedCarType { get; set; }

        public NewCarViewModel()
        {
            var x = new Dictionary<int, string>();
            x[1] = "Fiat";
            x[2] = "Form";
            x[3] = "Volksvagen";
            x[3] = "Mazda";
            x[4] = "Luxus";
            x[5] = "Kiya";

            CarTypes = x;
        }

    }

    public class Unit : DbContext
    {
        public Unit()
            : base("DefaultConnection")
        {

        }
        public DbSet<Car> Cars { get; set; }
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
}