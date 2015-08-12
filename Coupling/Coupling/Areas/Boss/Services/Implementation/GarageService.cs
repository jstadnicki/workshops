using System.Web.Mvc;
using Coupling.Areas.Boss.Controllers;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Implementation
{
    class GarageService : IGarageService
    {
        OperationResult IGarageService.TryAddGarage(AddGarageModel dto)
        {
            throw new System.NotImplementedException();
        }

        CreateGarageViewModel IGarageService.GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        GarageRemoveViewModel IGarageService.GetRemoveGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        ActionResult IGarageAddService.GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        CreateGarageViewModel IGarageService.GetCreateGarageViewModel(AddGarageModel dto)
        {
            throw new System.NotImplementedException();
        }

        GarageListViewModel IGarageService.GetListGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        ActionResult IGarageAddService.GetCreateGarageViewModel(AddGarageModel model)
        {
            throw new System.NotImplementedException();
        }

        OperationResult IGarageAddService.TryAddGarage(AddGarageModel model)
        {
            throw new System.NotImplementedException();
        }

        GarageListViewModel IGarageListService.GetListGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        GarageRemoveViewModel IGarageRemoveService.GetRemoveGarageViewModel()
        {
            throw new System.NotImplementedException();
        }
    }
}