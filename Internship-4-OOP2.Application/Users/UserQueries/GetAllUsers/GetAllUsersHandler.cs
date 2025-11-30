using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;

namespace Internship_4_OOP2.Application.Users.UserQueries.GetAllUsers
{
    internal class GetAllUsersHandler : RequestHandler<GetAllUsersRequest, IEnumerable<User>>
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task HandleRequest(GetAllUsersRequest request, Result<IEnumerable<User>> result)
        {
            var usersResponse = await _unitOfWork.UserRepository.Get();

            var users = usersResponse?.Values ?? new List<User>();

            result.SetResult(users);
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
