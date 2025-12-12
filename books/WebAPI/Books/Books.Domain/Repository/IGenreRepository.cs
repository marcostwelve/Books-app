using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Repository
{
    public interface IGenreRepository
    {
        Task<ICollection<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task UpdateAsync(Genre genre);
        Task<int> AddAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}
