using Internship_4_OOP2.Doimain.Common.Validation;

namespace Internship_4_OOP2.Application.Common.Model
{
    public class Result<TValue> where TValue : class
    {
        private List<ValidationResultItem> _infos = new List<ValidationResultItem>();
        private List<ValidationResultItem> _warnings = new List<ValidationResultItem>();
        private List<ValidationResultItem> _errors = new List<ValidationResultItem>();
        public TValue? Value { get; set; }
        public Guid RequestId { get; set; }
        public bool IsAuthorized { get; set; } = true;
        public IReadOnlyList<ValidationResultItem> Infos
        {
            get => _infos.AsReadOnly();
            init => _infos.AddRange(value);
        }

        public IReadOnlyList<ValidationResultItem> Warnings
        {
            get => _warnings.AsReadOnly();
            init => _warnings.AddRange(value);
        }

        public IReadOnlyList<ValidationResultItem> Errors
        {
            get => _errors.AsReadOnly();
            init => _errors.AddRange(value);
        }

        public bool HasInfo => Infos.Any(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Info);
        public bool HasWarning => Warnings.Any(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Warning);
        public bool HasError => Errors.Any(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Error);

        public void SetResult(TValue value)
        {
            Value = value;
        }

        public void SetValidationResult(ValidationResult validationResult)
        {
            _infos?.AddRange(validationResult.ValidationItems
                .Where(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Info)
                .Select(validationItem => ValidationResultItem.FromValidationItem(validationItem)));

            _warnings?.AddRange(validationResult.ValidationItems
                .Where(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Warning)
                .Select(validationItem => ValidationResultItem.FromValidationItem(validationItem)));

            _errors?.AddRange(validationResult.ValidationItems
                .Where(validationResult => validationResult.ValidationSeverity == Doimain.Common.Validation.Enumerations.ValidationSeverity.Error)
                .Select(validationItem => ValidationResultItem.FromValidationItem(validationItem)));
        }

        public void SetUnauthorizedResult()
        {
            Value = null;
            IsAuthorized = false;
        }
    }
}
