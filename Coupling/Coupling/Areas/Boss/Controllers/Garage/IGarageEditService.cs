using Coupling.Areas.Boss.Services.Garage.Implementation;

namespace Coupling.Areas.Boss.Controllers.GaragesController
{
    public interface IGarageEditService
    {
        GarageEditViewModel GetGarageEditViewModel(int garageId);
    }
}