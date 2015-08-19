namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using System.Web.Mvc;

    using Coupling.Controllers;

    class GarageService : IGarageAddService, 
                          IGarageListService, 
                          IGarageRemoveService
    {
        OperationResult TryAddGarage(AddGarageModel dto)
        {
            throw new System.NotImplementedException();
        }

        CreateGarageViewModel GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        GarageRemoveViewModel GetRemoveGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        ActionResult IGarageAddService.GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        CreateGarageViewModel GetCreateGarageViewModel(AddGarageModel dto)
        {
            throw new System.NotImplementedException();
        }

        GarageListViewModel GetListGarageViewModel()
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