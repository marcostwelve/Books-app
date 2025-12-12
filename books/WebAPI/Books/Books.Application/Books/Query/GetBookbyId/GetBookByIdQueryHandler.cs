using AutoMapper;
using Books.Domain.Dtos.View;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Query.GetBookbyId
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookViewDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            var bookView = _mapper.Map<BookViewDto>(book);

            return bookView;
        }
    }
}
