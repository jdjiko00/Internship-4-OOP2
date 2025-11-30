using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Common.Validation;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;

namespace Internship_4_OOP2.Application.Users.UserQueries.GetUserById
{
    internal class GetUserByIdHandler : RequestHandler<GetUserByIdRequest, User>
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task HandleRequest(GetUserByIdRequest request, Result<User> result)
        {
            var user = await _unitOfWork.UserRepository.GetById(request.Id);

            if (user == null)
            {
                var validationResult = new ValidationResult();
                validationResult.AddValidationItem(new ValidationItem
                {
                    Code = "NemaKorisnika",
                    Message = $"Korisnik s ID-em {request.Id} ne postoji",
                    ValidationSeverity = Doimain.Common.Validation.Enumerations.ValidationSeverity.Error,
                    ValidationType = Doimain.Common.Validation.Enumerations.ValidationType.BusinessRule
                });

                result.SetValidationResult(validationResult);
                return;
            }

            result.SetResult(user);
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
