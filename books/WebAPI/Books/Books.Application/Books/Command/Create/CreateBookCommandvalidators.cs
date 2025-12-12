using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Command.Create
{
    public class CreateBookCommandvalidators : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandvalidators() 
        {
            RuleFor(dto => dto.Title)
                .Length(3, 100)
                .WithMessage("Title must be between 3 and 100 characters.");
            RuleFor(dto => dto.Description)
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");
        }
    }
}
