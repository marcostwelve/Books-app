using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Books.Command.Delete
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
