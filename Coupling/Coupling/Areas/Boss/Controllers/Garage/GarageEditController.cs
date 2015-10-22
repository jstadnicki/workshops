namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    using System.Web.Mvc;
    using Coupling.Areas.Boss.Services.Garage;
    using Coupling.Controllers;

    [RouteArea("boss")]
    [RoutePrefix("garage")]
    public class GarageEditController : BaseController
    {
        private readonly IGarageEditService garageEditService;

        public GarageEditController(IGarageEditService garageEditService)
        {
            this.garageEditService = garageEditService;
        }

        [HttpGet]
        [Route("edit",Name = "garage/edit")]
        public ActionResult Edit(int garageId)
        {
            var viewModel = this.garageEditService.GetGarageEditViewModel();
            return this.View(viewModel);
        }
    }
}