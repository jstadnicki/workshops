using Coupling.Areas.Boss.Services.Garage.Implementation;

namespace Coupling.Areas.Boss.Services.Garage
{
    using System.Web.Mvc;

    using Coupling.Areas.Boss.Models.Garage;
    using Coupling.Controllers;

    public interface IGarageAddService
    {
        ActionResult GetCreateGarageViewModel();

        ActionResult GetCreateGarageViewModel(GarageAddViewModel viewModel);

        OperationResult TryAddGarage(GarageAddViewModel viewModel);
        ActionResult GetCreateGarageViewModel(AddGarageModel model);
        OperationResult TryAddGarage(AddGarageModel model);
    }
}