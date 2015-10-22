using System.Linq;
using System.Web.Mvc;
using Coupling.Areas.Boss.Controllers.GaragesController;
using Coupling.Areas.Boss.Models.Garage;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using System;

    class GarageService : IGarageAddService,
                          IGarageListService,
                          IGarageRemoveService,
                          IGarageEditService
    {
        private readonly IGarageRepository garageRepository;
        private readonly IGarageServiceMapper garageServiceMapper;

        public GarageService(IGarageRepository garageRepository,
                             IGarageServiceMapper garageServiceMapper)
        {
            this.garageRepository = garageRepository;
            this.garageServiceMapper = garageServiceMapper;
        }

        public GarageListViewModel GetGarageListViewModel()
        {
            var garages = this.garageRepository.GetGarageList();
            var garageListViewModel = this.garageServiceMapper.MapToGarageListViewModel(garages);
            return garageListViewModel;
        }

        public GarageAddViewModel GetCreateGarageViewModel()
        {
            return new GarageAddViewModel();
        }

        public GarageAddViewModel GetCreateGarageViewModel(GarageAddModel model)
        {
            throw new System.NotImplementedException();
        }

        //[HandleException(OnFail= ApplicationErrors.TryAddGarageFailed, typeof(Exception), typeof(InvalidCastException))]
        public OperationResult TryAddGarage(GarageAddModel model)
        {
            var garage = this.garageServiceMapper.MapToGarage(model);
            this.garageRepository.AddGarage(garage);
            return OperationResult.Ok();
        }

        public ActionResult GetCreateGarageViewModel(AddGarageModel model)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult TryAddGarage(AddGarageModel model)
        {
            throw new System.NotImplementedException();
        }

        public GarageRemoveViewModel GetRemoveGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        public GarageEditViewModel GetGarageEditViewModel(int garageId)
        {
        }
    }

    internal class HandleExceptionAttribute : Attribute
    {
        public HandleExceptionAttribute(object a, params object[] b)
        {
            
        }
    }

    public enum ApplicationErrors
    {
        TryAddGarageFailed,

        ModelStateIsInvalid,

        None,

        TryEditCarFailed
    }
}