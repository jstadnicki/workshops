using Coupling.Modern.Areas.Boss.Models.Garage;
using Coupling.Modern.Infrastructure;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Areas.Boss.Services.Garage.Implementation
{
    class GarageService : IGarageAddService, 
                          IGarageListService, 
                          IGarageRemoveService
    {
        private readonly IGarageRepository garageRepository;
        private readonly IMapper mapper;

        public GarageService(IGarageRepository garageRepository, IMapper mapper)
        {
            this.garageRepository = garageRepository;
            this.mapper = mapper;
        }

        public GarageListViewModel GetGarageListViewModel()
        {
            var garages = garageRepository.GetGarageList();
            var garageListViewModel = mapper.GetGarageListViewModel(garages);
            return garageListViewModel;
        }

        public IActionResult GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetCreateGarageViewModel(GarageAddViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult TryAddGarage(GarageAddViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetCreateGarageViewModel(AddGarageModel model)
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