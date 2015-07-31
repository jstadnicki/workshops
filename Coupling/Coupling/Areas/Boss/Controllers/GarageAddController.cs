namespace Coupling.Areas.Boss.Controllers
{
    using System.Web.Mvc;

    using Coupling.Controllers;

    using ControllerBase = Coupling.Controllers.ControllerBase;

    public partial class  GarageController : ControllerBase
    {
        private IGarageService garageService;

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = this.garageService.GetCreateGarageViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddGarageModel dto)
        {
            return this.Do(
                () => this.garageService.TryAddGarage(dto),
                success => this.RedirectToAction("Home"),
                failure =>
                    {
                        var viewModel = this.garageService.GetCreateGarageViewModel(dto);
                        return this.View(viewModel);
                    });
        }
    }

    public interface IGarageListService
    {
        GarageListViewModel GetListGarageViewModel();
    }

    public class GarageListViewModel
    {
    }

    public interface IGarageService
    {
        object GetCreateGarageViewModel(AddGarageModel dto);

        OperationResult TryAddGarage(AddGarageModel dto);

        object GetCreateGarageViewModel();
    }

    //public abstract class NewBaseController:Controller
    //{
    //    public abstract OperationResult Command();

    //    public virtual OperationResult OnFailure()
    //    {
    //        return OperationResult.Fail();
    //    }

    //    public virtual OperationResult OnSuccess()
    //    {
    //        return OperationResult.Ok();
    //    }

    //}
}