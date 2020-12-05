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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var booksListado = await _bookService.GetBooks();
            var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(booksListado);
            return Ok(booksDTO);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<IActionResult> Get(int id)
        {
            var libro = await _bookService.GetBook(id);

            if(libro == null)
            {
                return NotFound();
            }

            var libroDTO = _mapper.Map<BookDTO>(libro);

            return Ok(libroDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDTO libroDTO)
        {
            var newBook = _mapper.Map<Book>(libroDTO);
            await _bookService.InsertBook(newBook);
            return Created(nameof(Get), new {id = newBook.Id, libroDTO});
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookDTO libroDTO)
        {
            var currentLibro = await _bookService.GetBook(id);
            if(currentLibro == null)
            {
                return NotFound();
            }

            if(id != libroDTO.Id)
            {
                return BadRequest();
            }

            var updateLibro = _mapper.Map<Book>(libroDTO);
            updateLibro.Id = id;

            var result = await _bookService.UpdateBook(updateLibro);
            if(!result)
            {
                return BadRequest();
            }

           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentLibro = await _bookService.GetBook(id);
            if(currentLibro == null)
            {
                return NotFound();
            }

            var result = await _bookService.DeleteBook(id);
            if(!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}