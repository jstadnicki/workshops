namespace Coupling.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Coupling.Areas.Boss.Services.Garage.Implementation;

    public abstract class BaseController : Controller
    {
        protected ActionResult Do(
            Func<OperationResult> command,
            Func<OperationResult, ActionResult> onSuccess,
            Func<OperationResult, ActionResult> onFail)
        {
            if (!this.ModelState.IsValid)
            {
                return onFail(OperationResult.Fail(ApplicationErrors.ModelStateIsInvalid));
            }

            var result = command();

            if (!result.IsValid)
            {
                this.UpdateModelStateErrors(result.Errors);
                return onFail(result);
            }

            return onSuccess(result);
        }

        private void UpdateModelStateErrors(List<KeyValuePair<string, string>> result)
        {
            result.ForEach(x => this.ModelState.AddModelError(x.Key, x.Value));
        }
    }
}