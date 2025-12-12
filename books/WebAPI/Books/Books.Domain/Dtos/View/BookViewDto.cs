using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Dtos.View
{
    public class BookViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
