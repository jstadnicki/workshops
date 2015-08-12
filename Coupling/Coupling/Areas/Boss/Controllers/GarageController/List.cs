using System.Web.Mvc;
using Coupling.Areas.Boss.Services;

namespace Coupling.Areas.Boss.Controllers.GarageController
{
    using ControllerBase = Coupling.Controllers.ControllerBase;

    public partial class GarageController : ControllerBase
    {
        [HttpGet]
        public ActionResult List()
        {
            var viewModel = this.ListService.GetListGarageViewModel();
            return this.View(viewModel);
        }

        public IGarageListService ListService {
            get { return notForUse; }
        }
    }
}