using Books.Domain.Entities;
using Books.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Seeders
{
    public class DataSeeders : IDataSeeders
    {
        private readonly AppDbContext _context;
        public DataSeeders(AppDbContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Authors.Any())
                {
                    var authors = GetAuthors();
                    _context.Authors.AddRange(authors);
                    await _context.SaveChangesAsync();
                }

                if (!_context.Genres.Any())
                {
                    var genres = GetGenres();
                    _context.Genres.AddRange(genres);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private ICollection<Author> GetAuthors()
        {
            var authors = new List<Author>()
            {
                new (){ Name="George Orwell"},
                new (){ Name="Jane Austen"},
                new (){ Name="Mark Twain"},
                new (){ Name="J.K. Rowling"},
                new (){ Name="Ernest Hemingway"},
            };
            return authors;
        }

        private ICollection<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new (){ Name="Science Fiction"},
                new (){ Name="Romance"},
                new (){ Name="Adventure"},
                new (){ Name="Fantasy"},
                new (){ Name="Historical Fiction"},
            };
            return genres;
        }
    }
}
