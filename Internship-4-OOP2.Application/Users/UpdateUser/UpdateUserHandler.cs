using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Persistence.Users;

namespace Internship_4_OOP2.Application.Users.UpdateUser
{
    internal class UpdateUserHandler : RequestHandler<UpdateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task HandleRequest(UpdateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.UserRepository.GetById(request.Id);
            if (user == null)
            {
                var validationResult = new Doimain.Common.Validation.ValidationResult();
                validationResult.AddValidationItem(new Doimain.Common.Validation.ValidationItem
                {
                    Code = "NemaKorisnika",
                    Message = $"Korisnik s ID-em {request.Id} ne postoji",
                    ValidationSeverity = Doimain.Common.Validation.Enumerations.ValidationSeverity.Error,
                    ValidationType = Doimain.Common.Validation.Enumerations.ValidationType.BusinessRule
                });
                result.SetValidationResult(validationResult);
                return;
            }

            user.UpdateBasicInfo(request.Name, request.Email, request.Website);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();

            result.SetResult(new SuccessPostResponse(true, user.Id));
        }

        protected override Task<bool> IsAuthorized() => Task.FromResult(true);
    }
}
