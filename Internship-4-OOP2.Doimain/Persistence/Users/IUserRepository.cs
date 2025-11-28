using Internship_4_OOP2.Doimain.Entities;

namespace Internship_4_OOP2.Doimain.Persistence.Users
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
    }
}
