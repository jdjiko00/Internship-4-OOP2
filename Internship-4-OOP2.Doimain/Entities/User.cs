using Internship_4_OOP2.Doimain.Common.Validation;
using Internship_4_OOP2.Doimain.Common.Validation.ValidationItems;

namespace Internship_4_OOP2.Doimain.Entities
{
    public class User
    {
        public const int NameMaxLenght = 100;
        public const int UsernameMaxLenght = 100;
        public const int EmailMaxLenght = 255;
        public const int AddressStreetMaxLenght = 150;
        public const int AddressCityMaxLenght = 100;
        public const decimal GeoLatMaxRange = 90m;
        public const decimal GeoLngMaxRange = 180m;
        public const int WebsiteMaxLenght = 100;
        public const int PasswordMaxLenght = 100;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string AddressStreet { get; private set; }
        public string AddressCity { get; private set; }
        public decimal GeoLat { get; private set; }
        public decimal GeoLng { get; private set; }
        public string? Website { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public User (string name, string username, string email, string addressStreet, string addressCity, decimal geoLat, decimal geoLng, string? website)
        {
            Name = name;
            Username = username;
            Email = email;
            AddressStreet = addressStreet;
            AddressCity = addressCity;
            GeoLat = geoLat;
            GeoLng = geoLng;
            Website = website;

            Password = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateBasicInfo(string name, string email, string? website)
        {
            Name = name;
            Email = email;
            Website = website;
            UpdatedAt = DateTime.UtcNow;
        }

        public ValidationResult Validate()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Name))
                validationResult.AddValidationItem(ValidationItems.User.NameIsNull);

            else if (Name.Length > NameMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.NameMaxLenght);


            if (string.IsNullOrWhiteSpace(Username))
                validationResult.AddValidationItem(ValidationItems.User.UsernameIsNull);

            else if (Username.Length > UsernameMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.UsernameMaxLenght);


            if (string.IsNullOrWhiteSpace(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailIsNull);

            else  if (Email.Length > EmailMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.EmailMaxLenght);


            if (string.IsNullOrWhiteSpace(AddressStreet))
                validationResult.AddValidationItem(ValidationItems.User.AddressStreetIsNull);

            else if (AddressStreet.Length > AddressStreetMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.AddressStreetMaxLenght);


            if (string.IsNullOrWhiteSpace(AddressCity))
                validationResult.AddValidationItem(ValidationItems.User.AddressCityIsNull);

            else if (AddressCity.Length > AddressCityMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.AddressCityMaxLenght);


            if (GeoLat < -GeoLatMaxRange || GeoLat > GeoLatMaxRange)
                validationResult.AddValidationItem(ValidationItems.User.GeoLatMaxRange);


            if (GeoLng < -GeoLngMaxRange || GeoLng > GeoLngMaxRange)
                validationResult.AddValidationItem(ValidationItems.User.GeoLngMaxRange);


            if (Website?.Length > WebsiteMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.WebsiteMaxLenght);


            if (string.IsNullOrWhiteSpace(Password))
                validationResult.AddValidationItem(ValidationItems.User.PasswordIsNull);

            else if (Password.Length > PasswordMaxLenght)
                validationResult.AddValidationItem(ValidationItems.User.PasswordMaxLenght);

            return validationResult;
        }
    }
}
