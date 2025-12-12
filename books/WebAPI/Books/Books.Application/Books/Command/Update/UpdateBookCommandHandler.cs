using AutoMapper;
using Books.Domain.Entities;
using Books.Domain.Exceptions;
using Books.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Command.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id.ToString());
            }

            _mapper.Map(request, book);

            await _bookRepository.UpdateAsync(book);
        }
    }
}
