namespace Coupling.Areas.Boss.Controllers
{
    using System.Web.Mvc;

    using ControllerBase = Coupling.Controllers.ControllerBase;

    public class GarageRemoveController : ControllerBase
    {
        private readonly IGarageRemoveService garageRemoveService;

        public GarageRemoveController(IGarageRemoveService garageRemoveService)
        {
            this.garageRemoveService = garageRemoveService;
        }

        [HttpGet]
        public ActionResult Remove()
        {
            var viewModel = this.garageRemoveService.GetRemoveGarageViewModel();
            return this.View(viewModel);
        }

    }

    public interface IGarageRemoveService
    {
        GarageRemoveViewModel GetRemoveGarageViewModel();
    }

    public class GarageRemoveViewModel
    {
    }
}