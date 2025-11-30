using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Companies;

namespace Internship_4_OOP2.Application.Companies.CreateCompany
{
    internal class CreateCompanyHandler : RequestHandler<CreateCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;

        public CreateCompanyHandler(ICompanyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task HandleRequest(CreateCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var company = new Company(request.Name);

            var validationResult = company.Validate();
            if (validationResult.HasError)
            {
                result.SetValidationResult(validationResult);
                return;
            }

            await _unitOfWork.CompanyRepository.InsertAsync(company);
            await _unitOfWork.SaveAsync();

            result.SetResult(new SuccessPostResponse(true, company.Id));
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
