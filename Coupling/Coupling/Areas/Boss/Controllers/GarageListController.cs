namespace Coupling.Areas.Boss.Controllers
{
    using System.Web.Mvc;

    using ControllerBase = Coupling.Controllers.ControllerBase;

    public partial class GarageController : ControllerBase
    {
        private readonly IGarageListService garageListService;

        public GarageController(IGarageListService garageListService)
        {
            this.garageListService = garageListService;
        }

        [HttpGet]
        public ActionResult List()
        {
            var viewModel = this.garageListService.GetListGarageViewModel();
            return this.View(viewModel);
        }
        
    }
}