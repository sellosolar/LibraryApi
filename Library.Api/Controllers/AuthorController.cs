using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor(Author author)
        {
            await _authorRepository.InsertAuthor(author);
            return Ok(author);
        }
    }
}
