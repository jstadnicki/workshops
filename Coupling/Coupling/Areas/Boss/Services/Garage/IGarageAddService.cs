using Coupling.Areas.Boss.Models.Garage;
using Coupling.Areas.Boss.Services.Garage.Implementation;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage
{
    public interface IGarageAddService
    {
        CreateGarageViewModel GetCreateGarageViewModel();
        CreateGarageViewModel GetCreateGarageViewModel(GarageAddModel dto);

        OperationResult TryAddGarage(GarageAddModel dto);
    }
}