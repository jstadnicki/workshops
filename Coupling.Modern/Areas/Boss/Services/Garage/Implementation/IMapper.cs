using System.Collections.Generic;
using Coupling.Modern.Areas.Boss.Models.Garage;

namespace Coupling.Modern.Areas.Boss.Services.Garage.Implementation
{
    internal interface IMapper
    {
        GarageListViewModel GetGarageListViewModel(IEnumerable<DataModels.Garage> garages);
    }
}