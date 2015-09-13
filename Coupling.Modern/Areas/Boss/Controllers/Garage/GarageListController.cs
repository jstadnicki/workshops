using Coupling.Modern.Areas.Boss.Services.Garage;
using Coupling.Modern.Controllers;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Areas.Boss.Controllers.Garage
{
    //[RouteArea("")]
    [Area("boss")]
    [Route("garage")]
    public class GarageListController : BaseController
    {
        private readonly IGarageListService garageListService;

        public GarageListController(IGarageListService garageListService)
        {
            this.garageListService = garageListService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var viewModel = garageListService.GetGarageListViewModel();
            return View(viewModel);
        }
    }
}