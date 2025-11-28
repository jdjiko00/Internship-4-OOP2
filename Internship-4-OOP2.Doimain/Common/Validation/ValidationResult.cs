namespace Internship_4_OOP2.Doimain.Common.Validation
{
    public class ValidationResult
    {
        private List<ValidationItem> _validationItems = new List<ValidationItem>();
        public IReadOnlyList<ValidationItem> ValidationItems => _validationItems;

        public bool HasInfo => _validationItems.Any(validationResult => validationResult.ValidationSeverity == Enumerations.ValidationSeverity.Info);
        public bool HasWarning => _validationItems.Any(validationResult => validationResult.ValidationSeverity == Enumerations.ValidationSeverity.Warning);
        public bool HasError => _validationItems.Any(validationResult => validationResult.ValidationSeverity == Enumerations.ValidationSeverity.Error);

        public void AddValidationItem(ValidationItem validationItem)
        {
            _validationItems.Add(validationItem);
        }
    }
}
