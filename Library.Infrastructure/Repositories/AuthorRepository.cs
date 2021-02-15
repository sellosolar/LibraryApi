using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthorById(int AuthorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(e => e.Id == AuthorId);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task InsertAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
    }
}
