using Coupling.Modern.Areas.Boss.Services.Garage;
using Coupling.Modern.Controllers;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Areas.Boss.Controllers.Garage
{
    [Area("boss")]
    [Route("garage")]
    public class GarageRemoveController : BaseController
    {
        private readonly IGarageRemoveService garageRemoveService;

        public GarageRemoveController(IGarageRemoveService garageRemoveService)
        {
            this.garageRemoveService = garageRemoveService;
        }

        [HttpGet]
        [Route("remove",Name = "garage/remove")]
        public IActionResult Remove()
        {
            var viewModel = garageRemoveService.GetRemoveGarageViewModel();
            return View(viewModel);
        }
    }
}