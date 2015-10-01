namespace Coupling.Areas.Boss.Models.Garage
{
    using System.Collections.Generic;

    public class GarageListViewModel
    {
        public List<GarageViewModel> Garages { get; private set; }

        public GarageListViewModel(List<GarageViewModel> gvm)
        {
            this.Garages = gvm;
        }
    }

    public class GarageViewModel
    {
        public string Name { get; set; }
    }
}