using System.Linq;
using Coupling.Areas.Boss.Models.Garage;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
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
    }
}