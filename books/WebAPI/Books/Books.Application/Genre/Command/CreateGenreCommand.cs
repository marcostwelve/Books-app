using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Genre.Command
{
    public class CreateGenreCommand : IRequest
    {
        public string Name { get; set; }
    }
}
