using Coupling.Areas.Boss.Models.Garage;
using Coupling.Areas.Boss.Services.Garage.Implementation;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage
{
    public interface IGarageAddService
    {
        CreateGarageViewModel GetCreateGarageViewModel();
        CreateGarageViewModel GetCreateGarageViewModel(GarageAddViewModel dto);

        OperationResult TryAddGarage(GarageAddViewModel dto);
    }
}