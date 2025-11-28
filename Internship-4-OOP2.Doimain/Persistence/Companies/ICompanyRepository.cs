using Internship_4_OOP2.Doimain.Entities;

namespace Internship_4_OOP2.Doimain.Persistence.Companies
{
    public interface ICompanyRepository
    {
        Task<Company> GetById(int id);
    }
}
