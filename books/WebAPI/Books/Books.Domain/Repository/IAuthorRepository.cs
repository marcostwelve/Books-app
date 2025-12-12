using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task UpdateAsync(Author author);
        Task<int> AddAsync(Author author);
        Task DeleteAsync(int id);
    }
}
