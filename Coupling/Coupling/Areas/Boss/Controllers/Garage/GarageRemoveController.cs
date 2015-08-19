namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    using System.Web.Mvc;

    using Coupling.Areas.Boss.Services;
    using Coupling.Areas.Boss.Services.Garage;
    using Coupling.Controllers;

    [RouteArea("boss")]
    [RoutePrefix("garage")]
    public class GarageRemoveController : BaseController
    {
        private readonly IGarageRemoveService garageRemoveService;

        public GarageRemoveController(IGarageRemoveService garageRemoveService)
        {
            this.garageRemoveService = garageRemoveService;
        }

        [HttpGet]
        [Route("remove",Name = "garage/remove")]
        public ActionResult Remove()
        {
            var viewModel = this.garageRemoveService.GetRemoveGarageViewModel();
            return this.View(viewModel);
        }
    }
}