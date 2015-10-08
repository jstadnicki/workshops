namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using System.Collections.Generic;

    using Coupling.Areas.Boss.Models.Garage;
    using Coupling.DataModels;

    internal interface IGarageServiceMapper
    {
        GarageListViewModel MapToGarageListViewModel(List<Garage> garages);
        Garage MapToGarage(GarageAddModel garages);
    }
}