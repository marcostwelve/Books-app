using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Author
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommad>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(100).WithMessage("Author name must not exceed 100 characters.");
        }
    }
}
