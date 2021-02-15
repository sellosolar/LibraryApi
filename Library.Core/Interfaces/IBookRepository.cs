using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task InsertBook(Book book);
    }
}
