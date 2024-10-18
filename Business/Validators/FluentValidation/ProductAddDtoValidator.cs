using FluentValidation;
using Model.Dtos;

namespace Business.Validators.FluentValidation
{
    public class ProductAddDtoValidator:AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.CategoryId)
                .GreaterThan(-1)
                .WithMessage("Lütfen kategori seçiniz");
        }
    }
}
