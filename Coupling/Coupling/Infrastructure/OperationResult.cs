namespace Coupling.Controllers
{
    using System.Collections.Generic;

    public sealed class OperationResult
    {
        public static OperationResult Ok()
        {
            return new OperationResult(true);
        }

        public static OperationResult Fail()
        {
            return new OperationResult(false);
        }

        private OperationResult(bool isValid)
        {
            this.Errors = new List<KeyValuePair<string, string>>();
            this.IsValid = isValid;
        }

        public bool IsValid { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; set; }
    }
}