using Coupling.Modern.Areas.Boss.Models.Garage;
using Coupling.Modern.Areas.Boss.Services.Garage.Implementation;
using Coupling.Modern.Infrastructure;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Areas.Boss.Services.Garage
{
    public interface IGarageAddService
    {
        IActionResult GetCreateGarageViewModel();

        IActionResult GetCreateGarageViewModel(GarageAddViewModel viewModel);

        OperationResult TryAddGarage(GarageAddViewModel viewModel);
        IActionResult GetCreateGarageViewModel(AddGarageModel model);
        OperationResult TryAddGarage(AddGarageModel model);
    }
}