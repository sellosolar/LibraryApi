using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByEditorialId(int EditorialId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.IdEditorial == EditorialId);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task InsertBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}
