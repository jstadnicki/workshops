using System.Collections.Generic;

namespace Coupling.Areas.Boss.Services.Garage.Implementation
{
    using Coupling.DataModels;

    internal interface IGarageRepository
    {
        List<DataModels.Garage> GetGarageList();

        void AddGarage(Garage garage);
    }

    class GarageRepository : IGarageRepository
    {
        private static readonly List<Garage> Garages;

        static GarageRepository()
        {
            Garages = new List<Garage>();
        }

        public List<Garage> GetGarageList()
        {
            return Garages;
        }

        public void AddGarage(Garage garage)
        {
            Garages.Add(garage);
        }
    }
}