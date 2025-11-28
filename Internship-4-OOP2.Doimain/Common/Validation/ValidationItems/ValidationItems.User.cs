namespace Internship_4_OOP2.Doimain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem NameIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = "Ime ne smije biti prazno",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem NameMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime ne smije biti duze od {Entities.User.NameMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem UsernameIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}3",
                Message = "Korisnicko ime ne smije biti prazno",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem UsernameMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}4",
                Message = $"Korisnicko ime ne smije biti duze od {Entities.User.UsernameMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem EmailIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}5",
                Message = "Email ne smije biti prazan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem EmailMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}6",
                Message = $"Email ne smije biti duzi od {Entities.User.EmailMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem AddressStreetIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}7",
                Message = "Adresa ulice ne smije biti prazna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem AddressStreetMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}8",
                Message = $"Adresa ulice ne smije biti duza od {Entities.User.AddressStreetMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem AddressCityIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}9",
                Message = "Adresa grada ne smije biti prazna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem AddressCityMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}10",
                Message = $"Adresa grada ne smije biti duza od {Entities.User.AddressCityMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem GeoLatMaxRange = new ValidationItem
            {
                Code = $"{CodePrefix}11",
                Message = $"Geografska sirina mora biti izmedu -{Entities.User.GeoLatMaxRange} i {Entities.User.GeoLatMaxRange}",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem GeoLngMaxRange = new ValidationItem
            {
                Code = $"{CodePrefix}12",
                Message = $"Geografska duzina mora biti izmedu -{Entities.User.GeoLngMaxRange} i {Entities.User.GeoLngMaxRange}",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem WebsiteMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}13",
                Message = $"Web stranica ne smije biti duza od {Entities.User.WebsiteMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem PasswordIsNull = new ValidationItem
            {
                Code = $"{CodePrefix}14",
                Message = "Lozinka ne smije biti prazna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };

            public static readonly ValidationItem PasswordMaxLenght = new ValidationItem
            {
                Code = $"{CodePrefix}15",
                Message = $"Lozinka ne smije biti duza od {Entities.User.PasswordMaxLenght} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation
            };
        }
    }
}
