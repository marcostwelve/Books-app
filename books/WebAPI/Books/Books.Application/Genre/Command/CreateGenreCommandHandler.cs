using AutoMapper;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Genre.Command
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreEntity = _mapper.Map<Domain.Entities.Genre>(request);

            await _genreRepository.AddAsync(genreEntity);
        }
    }
}
