using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthors();
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(authorsDto);
        }

        [HttpGet("GetAuthorsForSelect")]
        public async Task<IActionResult> GetAuthorsForSelect()
        {
            var authors = await _authorRepository.GetAuthors();
            var authorsDto = _mapper.Map<List<AuthorDto>>(authors).Select(a => new
            {
                a.Id,
                Value = a.FullName
            });

            return Ok(authorsDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.InsertAuthor(author);

            return Ok(author);
        }
    }
}
