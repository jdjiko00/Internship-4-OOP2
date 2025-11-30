namespace Internship_4_OOP2.Application.Companies.DeleteCompany
{
    public class DeleteCompanyRequest
    {
        public int Id { get; set; }

        public DeleteCompanyRequest(int id)
        {
            Id = id;
        }

        public DeleteCompanyRequest()
        {

        }
    }
}
