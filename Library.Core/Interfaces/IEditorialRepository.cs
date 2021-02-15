using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IEditorialRepository
    {
        Task<IEnumerable<Editorial>> GetEditorials();

        Task<Editorial> GetEditorialById(int EditorialId);

        Task<bool> MaxBooksToRegisterReached(int EditorialId);

        Task InsertEditorial(Editorial editorial);
    }
}
