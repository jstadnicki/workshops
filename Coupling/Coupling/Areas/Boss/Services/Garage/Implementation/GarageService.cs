using System.Linq;
using System.Web.Mvc;
using Coupling.Areas.Boss.Models.Garage;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
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
            var garageListViewModel = this.garageServiceMapper.Map(garages);
            return garageListViewModel;
        }

        public CreateGarageViewModel GetCreateGarageViewModel()
        {
            return new CreateGarageViewModel();
        }

        public CreateGarageViewModel GetCreateGarageViewModel(GarageAddViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult TryAddGarage(GarageAddViewModel viewModel)
        {
            throw new System.NotImplementedException();
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
}