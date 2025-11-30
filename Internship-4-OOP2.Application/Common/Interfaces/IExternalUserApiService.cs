using Internship_4_OOP2.Doimain.Entities;

namespace Internship_4_OOP2.Application.Common.Interfaces
{
    public interface IExternalUserApiService
    {
        Task<List<User>> GetExternalUsersAsync();
    }
}
