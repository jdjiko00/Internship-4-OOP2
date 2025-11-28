namespace Internship_4_OOP2.Doimain.Persistence.Users
{
    public interface IUserUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
    