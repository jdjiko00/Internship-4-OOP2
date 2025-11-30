using Internship_4_OOP2.Doimain.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;
using Internship_4_OOP2.Infrastructure.Common.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Internship_4_OOP2.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetAllResponse<User>> Get()
        {
            var items = await _dbContext.Users.AsNoTracking().ToListAsync();

            return new GetAllResponse<User>
            {
                Values = items
            };
        }

        public async Task InsertAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Users.FindAsync(id);
            if (entity != null)
                _dbContext.Users.Remove(entity);
        }

        public void Delete(User? entity)
        {
            if (entity != null)
                _dbContext.Users.Remove(entity);
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
