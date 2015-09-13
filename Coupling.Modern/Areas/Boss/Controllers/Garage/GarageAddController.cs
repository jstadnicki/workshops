using Coupling.Modern.Areas.Boss.Models.Garage;
using Coupling.Modern.Areas.Boss.Services.Garage;
using Coupling.Modern.Controllers;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Areas.Boss.Controllers.Garage
{
    [Area("boss")]
    [Route("garage")]
    public class GarageAddController : BaseController
    {
        private readonly IGarageAddService garageAddService;

        public GarageAddController(IGarageAddService garageAddService)
        {
            this.garageAddService = garageAddService;
        }

        [HttpGet]
        [Route("add",Name = "garage/add")]
        public IActionResult Add()
        {
            var viewModel = garageAddService.GetCreateGarageViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(GarageAddViewModel dto)
        {
            return Do(
                () => garageAddService.TryAddGarage(dto),
                success => RedirectToRoute("garage/remove"),
                failure =>
                    {
                        var viewModel = garageAddService.GetCreateGarageViewModel(dto);
                        return View(viewModel);
                    });
        }
    }
}