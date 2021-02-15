using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();

        Task<Author> GetAuthorById(int AuthorId);

        Task InsertAuthor(Author authors);
    }
}
