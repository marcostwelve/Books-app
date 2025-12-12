using Books.Domain.Dtos.View;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Query.GetBookbyId
{
    public class GetBookByIdQuery : IRequest<BookViewDto>
    {
        public int Id { get; set; }
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
