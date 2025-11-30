using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Common.Validation;
using Internship_4_OOP2.Doimain.Persistence.Companies;

namespace Internship_4_OOP2.Application.Companies.DeleteCompany
{
    internal class DeleteCompanyHandler : RequestHandler<DeleteCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;

        public DeleteCompanyHandler(ICompanyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task HandleRequest(DeleteCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var company = await _unitOfWork.CompanyRepository.GetById(request.Id);

            if (company == null)
            {
                var validationResult = new ValidationResult();
                validationResult.AddValidationItem(new ValidationItem
                {
                    Code = "NemaKompanije",
                    Message = $"Kompanija s ID-em {request.Id} ne postoji",
                    ValidationSeverity = Doimain.Common.Validation.Enumerations.ValidationSeverity.Error,
                    ValidationType = Doimain.Common.Validation.Enumerations.ValidationType.BusinessRule
                });

                result.SetValidationResult(validationResult);
                return;
            }

            _unitOfWork.CompanyRepository.Delete(company);
            await _unitOfWork.SaveAsync();

            result.SetResult(new SuccessPostResponse(true, company.Id));
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
