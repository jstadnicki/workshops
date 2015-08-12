using Coupling.Areas.Boss.Controllers;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services
{
    public interface IGarageService: 
        IGarageAddService, 
        IGarageListService, 
        IGarageRemoveService
    {
        new GarageListViewModel GetListGarageViewModel();
        CreateGarageViewModel GetCreateGarageViewModel(AddGarageModel dto);
        OperationResult TryAddGarage(AddGarageModel dto);
        CreateGarageViewModel GetCreateGarageViewModel();
        GarageRemoveViewModel GetRemoveGarageViewModel();

    }
}