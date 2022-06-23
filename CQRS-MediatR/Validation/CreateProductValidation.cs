using CQRS_MediatR.DTO;
using FluentValidation;

namespace CQRS_MediatR.Validation;

public class CreateProductValidation : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty");
    }
}
