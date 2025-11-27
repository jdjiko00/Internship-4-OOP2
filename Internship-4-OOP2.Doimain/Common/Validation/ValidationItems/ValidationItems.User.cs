namespace Internship_4_OOP2.Doimain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem NameMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = $"Ime ne smije biti duze od {Entities.User.NameMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };
        }
    }
}
