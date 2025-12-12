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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);

            _context.Authors.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
            return authors;
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
