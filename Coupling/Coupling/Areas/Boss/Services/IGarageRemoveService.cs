using Coupling.Areas.Boss.Controllers;

namespace Coupling.Areas.Boss.Services
{
    using Coupling.Areas.Boss.Models;

    public interface IGarageRemoveService
    {
        GarageRemoveViewModel GetRemoveGarageViewModel();
    }
}