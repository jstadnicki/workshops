namespace Coupling.Areas.Boss.Controllers
{
    using System.Web.Mvc;

    using Coupling.Controllers;

    public interface IGarageAddService
    {
        ActionResult GetCreateGarageViewModel();

        ActionResult GetCreateGarageViewModel(AddGarageModel model);

        OperationResult TryAddGarage(AddGarageModel model);
    }
}