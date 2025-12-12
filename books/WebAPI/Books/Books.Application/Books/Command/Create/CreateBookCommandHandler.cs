using AutoMapper;
using Books.Domain.Entities;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Command.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository) 
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = _mapper.Map<Book>(request);

            int newBook = await _bookRepository.AddAsync(bookEntity);

            return newBook;
        }

    }
}
