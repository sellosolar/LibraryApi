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
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly IMapper _mapper;

        public EditorialController(IEditorialRepository editorialRepository, IMapper mapper)
        {
            _editorialRepository = editorialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEditorials()
        {
            var ediorial = await _editorialRepository.GetEditorials();
            var editorialsDto = _mapper.Map<IEnumerable<EditorialDto>>(ediorial);
            return Ok(editorialsDto);
        }

        [HttpGet("GetEditorialsForSelect")]
        public async Task<IActionResult> GetEditorialsForSelect()
        {
            var editorials = await _editorialRepository.GetEditorials();
            var editorialsDto = _mapper.Map<List<EditorialDto>>(editorials).Select(e => new
            {
                e.Id,
                Value = e.Name
            });

            return Ok(editorialsDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditorial(EditorialDto EditorialDto)
        {
            var editorial = _mapper.Map<Editorial>(EditorialDto);

            await _editorialRepository.InsertEditorial(editorial);
            return Ok(editorial);
        }
    }
}
