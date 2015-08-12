using System.Web.Mvc;
using Coupling.Areas.Boss.Services;

namespace Coupling.Areas.Boss.Controllers.GarageController
{
    using ControllerBase = Coupling.Controllers.ControllerBase;

    public partial class  GarageController : ControllerBase
    {
        public IGarageAddService AddService
        {
            get { return notForUse; }
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = AddService.GetCreateGarageViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddGarageModel dto)
        {
            return Do(
                () => AddService.TryAddGarage(dto),
                success => RedirectToAction("Home"),
                failure =>
                    {
                        var viewModel = AddService.GetCreateGarageViewModel(dto);
                        return View(viewModel);
                    });
        }
    }
}