using AutoMapper;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _GenreRepository;

        private readonly IMapper _mapper;

        public GenreController(IGenreRepository GenreRepository,

            IMapper mapper)
        {
            _GenreRepository = GenreRepository;

            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public IActionResult GetGenres()
        {
            var Genres = _mapper.Map<List<GenreDto>>(_GenreRepository.GetGenres());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Genres);
        }

        [HttpGet("{GenreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public IActionResult GetGenre(int GenreId)
        {
            if (!_GenreRepository.GenreExists(GenreId))
                return NotFound();

            var Genre = _mapper.Map<GenreDto>(_GenreRepository.GetGenre(GenreId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Genre);
        }







        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGenre([FromBody] GenreDto GenreCreate)
        {
            if (GenreCreate == null)
                return BadRequest(ModelState);

            var Genres = _GenreRepository.GetGenreTrimToUpper(GenreCreate);

            if (Genres != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var GenreMap = _mapper.Map<Genre>(GenreCreate);


            if (!_GenreRepository.CreateGenre(GenreMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }






        [HttpPut("{genreId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGenre(int genreId,
             [FromQuery] int GenreId,
            [FromBody] GenreDto updatedGenre)
        {
            if (updatedGenre == null)
                return BadRequest(ModelState);

            if (GenreId != updatedGenre.Id)
                return BadRequest(ModelState);

            if (!_GenreRepository.GenreExists(GenreId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var GenreMap = _mapper.Map<Genre>(updatedGenre);

            if (!_GenreRepository.UpdateGenre(GenreMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }





        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGenre(int pokeId)
        {
            if (!_GenreRepository.GenreExists(pokeId))
            {
                return NotFound();
            }


            var GenreToDelete = _GenreRepository.GetGenre(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_GenreRepository.DeleteGenre(GenreToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
