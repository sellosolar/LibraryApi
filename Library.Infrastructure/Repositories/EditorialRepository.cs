using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly LibraryContext _context;

        public EditorialRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> MaxBooksToRegisterReached(int EditorialId)
        {

            var editorial = await _context.Editorials
                .Include(e => e.Books)
                .FirstOrDefaultAsync(e => e.Id == EditorialId);

            if (editorial.MaxBooksToRegister > 0)
            {
                var registeredBooks = editorial.Books.Count;

                return editorial.MaxBooksToRegister <= registeredBooks;
            }

            return false;

        }

        public async Task<Editorial> GetEditorialById(int EditorialId)
        {
            return await _context.Editorials.FirstOrDefaultAsync(e => e.Id == EditorialId);
        }

        public async Task<IEnumerable<Editorial>> GetEditorials()
        {
            return await _context.Editorials.ToListAsync();
        }

        public async Task InsertEditorial(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            await _context.SaveChangesAsync();
        }
    }
}
