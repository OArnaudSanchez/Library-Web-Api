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
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GendersController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var generosListado = await _genderService.GetGenders();
            var generosDTO = _mapper.Map<IEnumerable<GenderDTO>>(generosListado);
            return Ok(generosDTO);
        }

        [HttpGet("{id}", Name = "GetGender")]
        public async Task<IActionResult> Get(int id)
        {
            var genero = await _genderService.GetGender(id);

            if(genero == null)
            {
                return NotFound();
            }

            var generoDTO = _mapper.Map<GenderDTO>(genero);

            return Ok(generoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenderDTO generoDTO)
        {
            var newGenero = _mapper.Map<Gender>(generoDTO);
            await _genderService.InsertGender(newGenero);
            return Created(nameof(Get), new {id = newGenero.Id, generoDTO});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GenderDTO generoDTO)
        {
            var currentGenero = await _genderService.GetGender(id);
            if(currentGenero == null)
            {
                return NotFound();
            }

            if(id != generoDTO.Id)
            {
                return BadRequest();
            }

            var updateGenero = _mapper.Map<Gender>(generoDTO);
            updateGenero.Id = id;

            var result = await _genderService.UpdateGender(updateGenero);
            if(!result)
            {
                return BadRequest();
            }

           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentGender = await _genderService.GetGender(id);
            if(currentGender == null)
            {
                return NotFound();
            }

            var result = await _genderService.DeleteGender(id);
            if(!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}