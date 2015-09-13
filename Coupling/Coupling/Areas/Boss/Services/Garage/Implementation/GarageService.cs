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

        public ActionResult GetCreateGarageViewModel()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult GetCreateGarageViewModel(GarageAddViewModel viewModel)
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