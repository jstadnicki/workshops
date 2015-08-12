using System.Web.Mvc;
using Coupling.Areas.Boss.Services;
using Coupling.Controllers;
using ControllerBase = Coupling.Controllers.ControllerBase;

namespace Coupling.Areas.Boss.Controllers.GarageController
{
    public partial class GarageController : ControllerBase
    {
        private readonly IGarageService notForUse;

        public GarageController(IGarageService notForUse)
        {
            this.notForUse = notForUse;
            this.notForUse.GetListGarageViewModel();
        }
    }
}