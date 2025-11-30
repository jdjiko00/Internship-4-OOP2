using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;

namespace Internship_4_OOP2.Application.Users
{
    internal class CreateUserHandler
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public CreateUserHandler(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected async Task<Result<SuccessPostResponse>> Handle(CreateUserRequest request)
        {
            var user = new User(
                request.Name,
                request.Username,
                request.Email,
                request.AddressStreet,
                request.AddressCity,
                request.GeoLat,
                request.GeoLng,
                request.Website
            );

            var result = new Result<SuccessPostResponse>();
            var validationResult = user.Validate();
            if (validationResult.HasError)
            {
                result.SetValidationResult(validationResult);
                return result;
            }

            await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            var response = new SuccessPostResponse
            {
                Id = user.Id,
                IsSuccess = true
            };

            result.SetResult(response);
            return result;
        }

        protected Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
