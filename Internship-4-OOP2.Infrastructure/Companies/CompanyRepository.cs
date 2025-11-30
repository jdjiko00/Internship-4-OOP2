using Internship_4_OOP2.Doimain.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Companies;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Internship_4_OOP2.Infrastructure.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _dbContext;

        public CompanyRepository(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetAllResponse<Company>> Get()
        {
            var items = await _dbContext.Companies.AsNoTracking().ToListAsync();

            return new GetAllResponse<Company>
            {
                Values = items
            };
        }

        public async Task InsertAsync(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
        }

        public void Update(Company entity)
        {
            _dbContext.Companies.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Companies.FindAsync(id);
            if (entity != null)
                _dbContext.Companies.Remove(entity);
        }

        public void Delete(Company? entity)
        {
            if (entity != null)
                _dbContext.Companies.Remove(entity);
        }

        public async Task<Company?> GetById(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
