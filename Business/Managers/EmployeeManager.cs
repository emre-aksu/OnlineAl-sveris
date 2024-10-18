using Business.Abstract;
using DataAccesLayer.Interface;
using FluentValidation;
using Model.Dtos;
using Model.Entities;

namespace Business.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IValidator<LogInDto> _loginDtoValidator;
        public EmployeeManager(IEmployeeRepository empRepo,   IValidator<LogInDto> loginDtoValidator)
        {
            _empRepo = empRepo; 
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<Employee> LogIn(LogInDto dto)
        {
            #region SERVER SIDE VALIDATION

            var  result = _loginDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                string errorMessages = string.Empty;

                foreach (var error in result.Errors)
                {
                    errorMessages += error.ErrorMessage + "<br/>";
                }
              //Validasyondan geçmediği durumda mvc ye bilgi verilecek
            }
            #endregion
            return await _empRepo.LogInAsync(dto.UserName, dto.Password);

        }
    }
}
