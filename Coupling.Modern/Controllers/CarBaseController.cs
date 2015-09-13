using System;
using System.Threading.Tasks;
using Coupling.Modern.Areas.Boss.Dtos;
using Coupling.Modern.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Controllers
{
    public class CarBaseController : BaseController
    {
        private readonly ICarApplicationService applicationService;

        public CarBaseController(ICarApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        public IActionResult List()
        {
            var viewModel = applicationService.GetCarsViewModel();
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = applicationService.GetCarDetailsViewModel(id);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = applicationService.GetCreateCarViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CarDto cardto)
        {
            return Do(
                () => applicationService.TrySaveNewCar(cardto),
                r => RedirectToAction("List"),
                r =>
                {
                    var viewModel = applicationService.GetCreateCarViewModel(cardto);
                    return View(viewModel);
                });
        }

        public IActionResult Edit(int carId)
        {
            var viewModel = applicationService.GetEditCarViewModel(carId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarDto editCarDto)
        {
            return await Do(
               async () => await applicationService.TryEditCar(editCarDto),
                x => RedirectToAction("Details", new { id = editCarDto.Id }),
                x =>
                {
                    var viewModel = applicationService.GetEditCarViewModel(editCarDto);
                    return View(viewModel);
                });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return await Do(
                async () => await applicationService.TryDeleteCar(id),
                x => RedirectToAction("List", "CarBase"),
                x =>
                {
                    throw new Exception("WHAT TO DO?");
                });
        }


    }
}