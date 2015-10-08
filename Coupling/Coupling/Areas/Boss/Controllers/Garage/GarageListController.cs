namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    using System.Web.Mvc;
    using Coupling.Areas.Boss.Services.Garage;
    using Coupling.Controllers;

    [RouteArea("boss")]
    [RoutePrefix("garage")]
    public class GarageListController : BaseController
    {
        private readonly IGarageListService garageListService;

        public GarageListController(IGarageListService garageListService)
        {
            this.garageListService = garageListService;
        }

        [HttpGet]
        [Route("list",Name = "garage/list")]
        public ActionResult List()
        {
            var viewModel = this.garageListService.GetGarageListViewModel();
            return this.View(viewModel);
        }
    }
}