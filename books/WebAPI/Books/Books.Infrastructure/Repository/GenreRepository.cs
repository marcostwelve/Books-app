using Books.Domain.Entities;
using Books.Domain.Repository;
using Books.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<int> AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
            
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _context.Genres
                .Include(g => g.Books)
                .FirstOrDefaultAsync(g => g.Id == id);
            return genre;
        }

        public async Task<ICollection<Genre>> GetGenresAsync()
        {
            var genres = await _context.Genres
                .Include(g => g.Books)
                .ToListAsync();
            return genres;
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }
    }
}
