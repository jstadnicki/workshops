using System.Web.Mvc;
using Coupling.Controllers;

namespace Coupling.Areas.Boss.Services
{
    using Coupling.Areas.Boss.Models;

    public interface IGarageAddService
    {
        ActionResult GetCreateGarageViewModel();

        ActionResult GetCreateGarageViewModel(AddGarageModel model);

        OperationResult TryAddGarage(AddGarageModel model);
    }
}