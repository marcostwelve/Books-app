using AutoMapper;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Author
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommad>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mediator;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mediator)
        {
            _authorRepository = authorRepository;
            _mediator = mediator;
        }
        public async Task Handle(CreateAuthorCommad request, CancellationToken cancellationToken)
        {
            var author = _mediator.Map<Domain.Entities.Author>(request);
            await _authorRepository.AddAsync(author);
        }
    }
}
