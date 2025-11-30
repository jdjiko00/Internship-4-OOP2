using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Companies;

namespace Internship_4_OOP2.Application.Companies.CompanyQueries.GetAllCompanies
{
    internal class GetAllCompaniesHandler : RequestHandler<GetAllCompaniesRequest, List<Company>>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;

        public GetAllCompaniesHandler(ICompanyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task HandleRequest(GetAllCompaniesRequest request, Result<List<Company>> result)
        {
            var companiesResponse = await _unitOfWork.CompanyRepository.Get();
            result.SetResult(companiesResponse.Values.ToList());
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
