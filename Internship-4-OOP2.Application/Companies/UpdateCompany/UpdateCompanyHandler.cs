using Internship_4_OOP2.Application.Common.Model;
using Internship_4_OOP2.Doimain.Common.Validation;
using Internship_4_OOP2.Doimain.Persistence.Companies;

namespace Internship_4_OOP2.Application.Companies.UpdateCompany
{
    internal class UpdateCompanyHandler : RequestHandler<UpdateCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;

        public UpdateCompanyHandler(ICompanyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task HandleRequest(UpdateCompanyRequest request, Result<SuccessPostResponse> result)
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

            company.UpdateBasicInfo(request.Name);

            var validation = company.Validate();
            if (validation.HasError)
            {
                result.SetValidationResult(validation);
                return;
            }

            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.SaveAsync();

            result.SetResult(new SuccessPostResponse(true, company.Id));
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
