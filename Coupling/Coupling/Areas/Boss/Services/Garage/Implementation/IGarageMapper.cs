namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using System.Collections.Generic;

    using Coupling.Areas.Boss.Models.Garage;
    using Coupling.DataModels;

    internal interface IGarageServiceMapper
    {
        GarageListViewModel Map(List<Garage> garages);
    }
}