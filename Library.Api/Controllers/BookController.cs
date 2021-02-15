using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IEditorialRepository editorialRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _editorialRepository = editorialRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            var editorial = await _editorialRepository.GetEditorialById(book.IdEditorial);
            if (editorial is null)
            {
                throw new CustomException($"La editorial no está registrada.");
            }

            var maxReached = await _editorialRepository.MaxBooksToRegisterReached(book.IdEditorial);
            if (maxReached)
            {
                throw new CustomException($"No es posible registrar el libro, se alcanzó el máximo permitido para la editorial seleccionada.");
            }

            var author = await _authorRepository.GetAuthorById(book.IdAuthor);
            if (author is null)
            {
                throw new CustomException($"El autor no está registrado.");
            }

            await _bookRepository.InsertBook(book);

            return Ok(_mapper.Map<BookDto>(book));
        }
    }
}
