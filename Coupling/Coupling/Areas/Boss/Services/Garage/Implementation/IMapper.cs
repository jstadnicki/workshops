using System.Collections.Generic;
using Coupling.Areas.Boss.Models.Garage;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    internal interface IMapper
    {
        GarageListViewModel GetGarageListViewModel(IEnumerable<DataModels.Garage> garages);
    }
}