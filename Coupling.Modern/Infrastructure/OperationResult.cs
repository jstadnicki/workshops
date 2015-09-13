using System.Collections.Generic;

namespace Coupling.Modern.Infrastructure
{
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
            Errors = new List<KeyValuePair<string, string>>();
            IsValid = isValid;
        }

        public bool IsValid { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; set; }
    }
}