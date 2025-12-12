using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Repository
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task UpdateAsync(Book book);
        Task<int> AddAsync(Book book);
        Task DeleteAsync(Book id);
    }
}
