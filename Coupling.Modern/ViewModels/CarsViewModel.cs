using System.Collections.Generic;

namespace Coupling.Modern.ViewModels
{
    public class CarsViewModel
    {
        public CarsViewModel()
        {
            Cars = new List<CarViewModel>();
        }

        public List<CarViewModel> Cars { get; set; }
    }
}