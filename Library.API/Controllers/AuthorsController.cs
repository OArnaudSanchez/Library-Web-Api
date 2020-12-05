using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core;
using Library.Core.DTos;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController: ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authorsList = await _authorService.GetAuthors();
            var authorsDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authorsList);
            return Ok(authorsDTO);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _authorService.GetAuthor(id);

            if(author == null)
            {
                return NotFound();
            }

            var authorDTO = _mapper.Map<AuthorDTO>(author);

            return Ok(authorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDTO authorDTO)
        {
            var newAuthor = _mapper.Map<Author>(authorDTO);
            await _authorService.InsertAuthor(newAuthor);
            return Created(nameof(Get), new {id = newAuthor.Id, newAuthor});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorDTO authorDTO)
        {
            var currentAuthor = await _authorService.GetAuthor(id);
            if(currentAuthor == null)
            {
                return NotFound();
            }

            if(id != authorDTO.Id)
            {
                return BadRequest();
            }

            var updateAuthor = _mapper.Map<Author>(authorDTO);
            updateAuthor.Id = id;

            var result = await _authorService.UpdateAuthor(updateAuthor);
            if(!result)
            {
                return BadRequest();
            }

           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentAuthor = await _authorService.GetAuthor(id);
            if(currentAuthor == null)
            {
                return NotFound();
            }

            var result = await _authorService.DeleteAuthor(id);
            if(!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}