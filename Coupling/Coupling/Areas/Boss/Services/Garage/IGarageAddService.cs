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
    }
}