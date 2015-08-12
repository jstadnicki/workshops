using System.Web.Mvc;
using Coupling.Areas.Boss.Services;

namespace Coupling.Areas.Boss.Controllers.GarageController
{
    using ControllerBase = Coupling.Controllers.ControllerBase;

    public partial class GarageController : ControllerBase
    {
        [HttpGet]
        public ActionResult Remove()
        {
            var viewModel = this.RemoveService.GetRemoveGarageViewModel();
            return this.View(viewModel);
        }

        public IGarageRemoveService RemoveService
        {
            get { return notForUse; }
        }
    }
}