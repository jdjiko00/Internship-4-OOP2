using Internship_4_OOP2.Doimain.Entities;

namespace Internship_4_OOP2.Infrastructure.Common.ExternalApi
{
    public interface IExternalUserApiService
    {
        Task<IEnumerable<User>> GetExternalUsersAsync();
    }
}
