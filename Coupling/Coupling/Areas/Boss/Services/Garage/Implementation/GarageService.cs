using System.Linq;
using System.Web.Mvc;
using Coupling.Areas.Boss.Models.Garage;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using System;

    class GarageService : IGarageAddService, 
                          IGarageListService, 
                          IGarageRemoveService
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

        public CreateGarageViewModel GetCreateGarageViewModel()
        {
            return new CreateGarageViewModel();
        }

        public CreateGarageViewModel GetCreateGarageViewModel(GarageAddModel model)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult TryAddGarage(GarageAddModel model)
        {
            try
            {
                this.AddGarage(model);
            }
            catch
            {
                return OperationResult.Fail(ApplicationErrors.TryAddGarageFailed);
            }

            return OperationResult.Ok();
        }

        private void AddGarage(GarageAddModel model)
        {
            var garage = this.garageServiceMapper.MapToGarage(model);
            this.garageRepository.AddGarage(garage);
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
    }

    public enum ApplicationErrors
    {
        TryAddGarageFailed,

        ModelStateIsInvalid,

        None,

        TryEditCarFailed
    }
}