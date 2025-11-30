using Internship_4_OOP2.Doimain.Persistence.Common;

namespace Internship_4_OOP2.Doimain.Persistence.Companies
{
    public interface ICompanyUnitOfWork : IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
    }
}
