using System.Web.Mvc;
using Coupling.Areas.Boss.Controllers;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services
{
    public interface IGarageAddService
    {
        ActionResult GetCreateGarageViewModel();

        ActionResult GetCreateGarageViewModel(AddGarageModel model);

        OperationResult TryAddGarage(AddGarageModel model);
    }
}