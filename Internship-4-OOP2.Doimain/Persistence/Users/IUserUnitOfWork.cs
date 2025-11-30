using Internship_4_OOP2.Doimain.Persistence.Common;

namespace Internship_4_OOP2.Doimain.Persistence.Users
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
    