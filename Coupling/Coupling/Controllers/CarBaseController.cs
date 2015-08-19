using System.Web.Mvc;

namespace Coupling.Controllers
{
    using System;

    using Coupling.Areas.Boss.Dtos;
    using Coupling.Interfaces;

    public class CarBaseController : BaseController
    {
        private readonly ICarApplicationService _applicationService;

        public CarBaseController(ICarApplicationService applicationService)
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
            return this.Do(
                () => _applicationService.TrySaveNewCar(cardto),
                r => RedirectToAction("List"),
                r =>
                {
                    var viewModel = _applicationService.GetCreateCarViewModel(cardto);
                    return View(viewModel);
                });
        }

        public ActionResult Edit(int carId)
        {
            var viewModel = _applicationService.GetEditCarViewModel(carId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCarDto EditCarDto)
        {
            return this.Do(
                () => _applicationService.TryEditCar(EditCarDto),
                x => RedirectToAction("Details", new { id = EditCarDto.Id }),
                x =>
                {
                    var viewModel = _applicationService.GetEditCarViewModel(EditCarDto);
                    return View(viewModel);
                });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return this.Do(
                () => _applicationService.TryDeleteCar(id),
                x => RedirectToAction("List", "CarBase"),
                x =>
                {
                    throw new Exception("WHAT TO DO?");
                });
        }


    }
}