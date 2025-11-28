using Internship_4_OOP2.Doimain.Common.Validation.Enumerations;

namespace Internship_4_OOP2.Application.Common.Model
{
    public class ValidationResultItem
    {
        public ValidationSeverity ValidationSeverity { get; init; }
        public ValidationType ValidationType { get; init; }
        public string Code { get; set; }
        public string Message { get; set; }

        public static ValidationResultItem FromValidationItem(ValidationResultItem item)
        {
            return new ValidationResultItem
            {
                ValidationSeverity = item.ValidationSeverity,
                ValidationType = item.ValidationType,
                Code = item.Code,
                Message = item.Message
            };
        }
    }
}
