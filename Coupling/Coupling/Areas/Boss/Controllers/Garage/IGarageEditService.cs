using Coupling.Areas.Boss.Services.Garage.Implementation;

namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    public interface IGarageEditService
    {
        GarageEditViewModel GetGarageEditViewModel();
    }

    class GarageEditService : IGarageEditService
    {
        public GarageEditViewModel GetGarageEditViewModel()
        {
            throw new System.NotImplementedException();
        }
    }
}