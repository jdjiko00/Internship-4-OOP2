namespace Internship_4_OOP2.Doimain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Company
        {
            public static string CodePrefix = nameof(Company);

            public static readonly ValidationItem NameIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = "Ime ne smije biti prazno",
                ValidationSeverity = Enumerations.ValidationSeverity.Error,
                ValidationType = Enumerations.ValidationType.FormalValidation
            };

            public static readonly ValidationItem NameMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime ne smije biti duze od {Entities.Company.NameMaxLenght} znakova",
                ValidationSeverity = Enumerations.ValidationSeverity.Error,
                ValidationType = Enumerations.ValidationType.FormalValidation
            };
        }
    }
}
