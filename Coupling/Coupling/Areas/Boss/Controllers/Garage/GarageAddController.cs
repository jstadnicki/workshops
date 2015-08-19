namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    using System.Web.Mvc;

    using Coupling.Areas.Boss.Models;
    using Coupling.Areas.Boss.Models.Garage;
    using Coupling.Areas.Boss.Services;
    using Coupling.Areas.Boss.Services.Garage;
    using Coupling.Controllers;

    [RouteArea("boss")]
    [RoutePrefix("garage")]
    public class GarageAddController : BaseController
    {
        private readonly IGarageAddService garageAddService;

        public GarageAddController(IGarageAddService garageAddService)
        {
            this.garageAddService = garageAddService;
        }

        [HttpGet]
        [Route("add",Name = "garage/add")]
        public ActionResult Add()
        {
            var viewModel = garageAddService.GetCreateGarageViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(GarageAddViewModel dto)
        {
            return Do(
                () => garageAddService.TryAddGarage(dto),
                success => RedirectToRoute("garage/remove"),
                failure =>
                    {
                        var viewModel = garageAddService.GetCreateGarageViewModel(dto);
                        return View(viewModel);
                    });
        }
    }
}