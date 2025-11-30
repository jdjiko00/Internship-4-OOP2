using Internship_4_OOP2.Doimain.Persistence.Users;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Internship_4_OOP2.Infrastructure.Users
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public IUserRepository UserRepository { get; }

        public UserUnitOfWork(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
        }

        public async Task CreateTransactions()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task Rollback()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
