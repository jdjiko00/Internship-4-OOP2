namespace Internship_4_OOP2.Doimain.Persistence.Common
{
    public interface IUnitOfWork
    {
        Task CreateTransactions();
        Task Commit();
        Task Rollback();
        Task SaveAsync();
    }
}
