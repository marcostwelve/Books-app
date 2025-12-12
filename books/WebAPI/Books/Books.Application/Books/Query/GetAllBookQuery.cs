using Books.Domain.Dtos.View;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Query
{
    public class GetAllBookQuery : IRequest<ICollection<BookViewDto>>
    {
    }
}
