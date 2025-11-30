using Internship_4_OOP2.Doimain.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Companies;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Dapper;

namespace Internship_4_OOP2.Infrastructure.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _dbContext;
        private readonly string _connectionString;

        public CompanyRepository(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task<GetAllResponse<Company>> Get()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = @"
                SELECT Id, Name
                FROM Companies
            ";
            var companies = await connection.QueryAsync<Company>(sql);

            return new GetAllResponse<Company>
            {
                Values = companies
            };
        }

        public async Task<Company?> GetById(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = @"
                SELECT Id, Name
                FROM Companies
                WHERE Id = @Id
            ";
            return await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
        }

        public async Task InsertAsync(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
        }

        public void Update(Company entity)
        {
            _dbContext.Companies.Update(entity);
        }

        public void Delete(Company? entity)
        {
            if (entity != null)
                _dbContext.Companies.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Companies.FindAsync(id);
            if (entity != null)
                _dbContext.Companies.Remove(entity);
        }
    }
}
