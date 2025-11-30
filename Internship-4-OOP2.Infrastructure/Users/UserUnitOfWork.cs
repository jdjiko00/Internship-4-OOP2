using Internship_4_OOP2.Doimain.Persistence.Users;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;

namespace Internship_4_OOP2.Infrastructure.Users
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserDbContext _dbContext;

        public UserUnitOfWork(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
        }

        public IUserRepository UserRepository { get; }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateTransactions()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
