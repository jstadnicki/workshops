using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coupling.Modern.Infrastructure;
using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Controllers
{
    public abstract class BaseController : Controller
    {
        protected async Task<IActionResult> Do(
            Func<Task<OperationResult>> command,
            Func<OperationResult, IActionResult> onSuccess,
            Func<OperationResult, IActionResult> onFail)
        {
            if (false == ModelState.IsValid)
            {
                return onFail(OperationResult.Fail());
            }
            
            var result = await command();

            if (result.IsValid)
            {
                return onSuccess(result);
            }
            UpdateModelStateErrors(result.Errors);
            return onFail(result);
        }

        protected IActionResult Do(
     Func<OperationResult> command,
     Func<OperationResult, IActionResult> onSuccess,
     Func<OperationResult, IActionResult> onFail)
        {
            if (false == ModelState.IsValid)
            {
                return onFail(OperationResult.Fail());
            }

            var result = command();

            if (!result.IsValid)
            {
                UpdateModelStateErrors(result.Errors);
                return onFail(result);
            }

            return onSuccess(result);
        }


        private void UpdateModelStateErrors(List<KeyValuePair<string, string>> result)
        {
            result.ForEach(x => ModelState.AddModelError(x.Key, x.Value));
        }
    }
}