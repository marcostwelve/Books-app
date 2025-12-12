using AutoMapper;
using Books.Domain.Dtos.View;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Query
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, ICollection<BookViewDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetAllBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<BookViewDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync();

            var bookViews = _mapper.Map<ICollection<BookViewDto>>(books);

            return bookViews;
        }
    }
}
