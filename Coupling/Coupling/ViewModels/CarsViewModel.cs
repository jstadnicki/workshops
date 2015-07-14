namespace Coupling.Controllers
{
    using System.Collections.Generic;

    public class CarsViewModel
    {
        public CarsViewModel()
        {
            this.Cars = new List<CarViewModel>();
        }

        public List<CarViewModel> Cars { get; set; }
    }
}