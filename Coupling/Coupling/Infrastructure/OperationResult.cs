namespace Coupling.Controllers
{
    using System.Collections.Generic;

    using Coupling.Areas.Boss.Services.Garage.Implementation;

    public sealed class OperationResult
    {
        public static OperationResult Ok()
        {
            return new OperationResult(true, ApplicationErrors.None);
        }

        public static OperationResult Fail(ApplicationErrors errorValue)
        {
            return new OperationResult(false, errorValue);
        }

        private OperationResult(bool isValid, ApplicationErrors errorValue)
        {
            this.Errors = new List<KeyValuePair<string, string>>();
            this.IsValid = isValid;
            this.ErrorValue = errorValue;
        }

        public bool IsValid { get; set; }

        public ApplicationErrors ErrorValue { get; set; }

        public List<KeyValuePair<string, string>> Errors { get; set; }
    }
}