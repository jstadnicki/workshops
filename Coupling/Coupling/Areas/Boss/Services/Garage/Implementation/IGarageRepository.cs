using System.Collections.Generic;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using Coupling.DataModels;

    internal interface IGarageRepository
    {
        List<DataModels.Garage> GetGarageList();
    }

    class GarageRepository : IGarageRepository
    {
        public List<Garage> GetGarageList()
        {
            var garages = new List<Garage>
                              {
                                  new Garage
                                      {
                                          Name = "Gara¿ na œwiebodzkim",
                                          Vehicles = new List<Vehicle>()
                                      }
                              };
            return garages;
        }
    }
}