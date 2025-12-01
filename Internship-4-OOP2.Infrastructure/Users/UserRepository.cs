using Internship_4_OOP2.Doimain.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Dapper;

namespace Internship_4_OOP2.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        private readonly string _connectionString;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task<GetAllResponse<User>> Get()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = @"
                SELECT 
                    id,
                    name,
                    username,
                    email,
                    address_street AS ""AddressStreet"",
                    address_city AS ""AddressCity"",
                    geo_lat AS ""GeoLat"",
                    geo_lng AS ""GeoLng"",
                    website,
                    password,
                    created_at AS ""CreatedAt"",
                    updated_at AS ""UpdatedAt"",
                    is_active AS ""IsActive""
                FROM users
            ";
            var users = await connection.QueryAsync<User>(sql);

            return new GetAllResponse<User>
            {
                Values = users.ToList()
            };
        }

        public async Task<User?> GetById(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = @"
                SELECT 
                    id,
                    name,
                    username,
                    email,
                    address_street AS ""AddressStreet"",
                    address_city AS ""AddressCity"",
                    geo_lat AS ""GeoLat"",
                    geo_lng AS ""GeoLng"",
                    website,
                    password,
                    created_at AS ""CreatedAt"",
                    updated_at AS ""UpdatedAt"",
                    is_active AS ""IsActive""
                FROM users
                WHERE id = @Id
            ";
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task InsertAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
        }

        public void Delete(User? entity)
        {
            if (entity != null)
                _dbContext.Users.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Users.FindAsync(id);
            if (entity != null)
                _dbContext.Users.Remove(entity);
        }
    }
}
