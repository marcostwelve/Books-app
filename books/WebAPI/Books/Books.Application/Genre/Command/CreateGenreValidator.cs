using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Genre.Command
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Genre name is required.")
                .MaximumLength(100).WithMessage("Genre name must not exceed 100 characters.");
        }
    }
}
