using Internship_4_OOP2.Doimain.Persistence.Companies;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Internship_4_OOP2.Infrastructure.Companies
{
    public class CompanyUnitOfWork : ICompanyUnitOfWork
    {
        private readonly CompanyDbContext _dbContext;

        public CompanyUnitOfWork(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
            CompanyRepository = new CompanyRepository(_dbContext);
        }

        public ICompanyRepository CompanyRepository { get; }

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
