using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Common;

namespace Internship_4_OOP2.Doimain.Persistence.Companies
{
    public interface ICompanyRepository : IRepository<Company, int>
    {
        Task<Company?> GetById(int id);
    }
}
