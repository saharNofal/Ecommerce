using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 char");
                
        }
    }
}
