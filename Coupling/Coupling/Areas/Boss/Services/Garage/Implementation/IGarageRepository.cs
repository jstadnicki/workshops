using System.Collections.Generic;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    internal interface IGarageRepository
    {
        List<DataModels.Garage> GetGarageList();
    }
}