using Internship_4_OOP2.Doimain.Common.Validation;
using Internship_4_OOP2.Doimain.Common.Validation.ValidationItems;

namespace Internship_4_OOP2.Doimain.Entities
{
    public class Company
    {
        public const int NameMaxLenght = 150;

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Company(string name)
        {
            Name = name;
        }

        public void UpdateBasicInfo(string name)
        {
            Name = name;
        }

        public ValidationResult Validate()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Name))
                validationResult.AddValidationItem(ValidationItems.Company.NameIsNull);

            else if (Name.Length > NameMaxLenght)
                validationResult.AddValidationItem(ValidationItems.Company.NameMaxLenght);

            return validationResult;
        }
    }
}
