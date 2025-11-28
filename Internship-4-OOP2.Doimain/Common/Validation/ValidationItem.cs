using Internship_4_OOP2.Doimain.Common.Validation.Enumerations;

namespace Internship_4_OOP2.Doimain.Common.Validation
{
    public class ValidationItem
    {
        public ValidationSeverity ValidationSeverity { get; init; }
        public ValidationType ValidationType {  get; init; }
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
