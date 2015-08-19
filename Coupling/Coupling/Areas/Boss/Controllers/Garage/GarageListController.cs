namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    using System.Web.Mvc;

    using Coupling.Areas.Boss.Services;
    using Coupling.Controllers;
    //[RouteArea("")]
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
        [Route("list")]
        public ActionResult List()
        {
            var viewModel = this.garageListService.GetListGarageViewModel();
            return this.View(viewModel);
        }
    }
}