using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Common;

namespace Internship_4_OOP2.Doimain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(int id);
    }
}
