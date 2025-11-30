using Internship_4_OOP2.Doimain.Persistence.Companies;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Internship_4_OOP2.Infrastructure.Companies
{
    public class CompanyUnitOfWork : ICompanyUnitOfWork
    {
        private readonly CompanyDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public ICompanyRepository CompanyRepository { get; }

        public CompanyUnitOfWork(CompanyDbContext dbContext, ICompanyRepository companyRepository)
        {
            _dbContext = dbContext;
            CompanyRepository = companyRepository;
        }

        public async Task CreateTransactions()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();

            if (_transaction != null)
                await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
