using System.Collections.Generic;
using Coupling.Areas.Boss.Models.Garage;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using Coupling.DataModels;

    internal class ServiceMapper : IGarageServiceMapper
    {
        public GarageListViewModel Map(List<Garage> garages)
        {
            var garageListViewModel = AutoMapper.Mapper.Map<GarageListViewModel>(garages);
            return garageListViewModel;
        }
    }
}