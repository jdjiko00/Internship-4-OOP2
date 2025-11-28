namespace Internship_4_OOP2.Doimain.Persistence.Companies
{
    public interface ICompanyUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
    }
}
