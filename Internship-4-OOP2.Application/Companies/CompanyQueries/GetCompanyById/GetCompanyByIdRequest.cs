namespace Internship_4_OOP2.Application.Companies.CompanyQueries.GetCompanyById
{
    public class GetCompanyByIdRequest
    {
        public int Id { get; init; }

        public GetCompanyByIdRequest(int id)
        {
            Id = id;
        }

        public GetCompanyByIdRequest()
        {

        }
    }
}
