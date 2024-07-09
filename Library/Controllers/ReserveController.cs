using AutoMapper;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : Controller
    {
        private readonly IReserveRepository _ReserveRepository;
        private readonly IMapper _mapper;
        
        private readonly IBookRepository _bookRepository;

        public ReserveController(IReserveRepository ReserveRepository,
            IMapper mapper,
            IBookRepository bookRepository)
        {
            _ReserveRepository = ReserveRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reserves>))]
        public IActionResult GetReserves()
        {
            var Reserves = _mapper.Map<List<ReservesDto>>(_ReserveRepository.GetReserves());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Reserves);
        }

        [HttpGet("{ReserveId}")]
        [ProducesResponseType(200, Type = typeof(Reserves))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int ReserveId)
        {
            if (!_ReserveRepository.ReserveExists(ReserveId))
                return NotFound();

            var Reserve = _mapper.Map<ReservesDto>(_ReserveRepository.GetReserve(ReserveId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Reserve);
        }

        [HttpGet("book/{bookId}")]
        [ProducesResponseType(200, Type = typeof(Reserves))]
        [ProducesResponseType(400)]
        public IActionResult GetReservesForAPokemon(int bookId)
        {
            var Reserves = _mapper.Map<List<ReservesDto>>(_ReserveRepository.GetReserveByBookCopy(bookId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(Reserves);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReserve( [FromBody] ReservesDto ReserveCreate)
        {
            if (ReserveCreate == null)
                return BadRequest(ModelState);

            var Reserves = _ReserveRepository.GetReserves()
               
                .FirstOrDefault();

            if (Reserves != null)
            {
                ModelState.AddModelError("", "Reserve already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ReserveMap = _mapper.Map<Reserves>(ReserveCreate);

            
           


            if (!_ReserveRepository.CreateReserve(ReserveMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{ReserveId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReserve(int ReserveId, [FromBody] ReservesDto updatedReserve)
        {
            if (updatedReserve == null)
                return BadRequest(ModelState);

            if (ReserveId != updatedReserve.Id)
                return BadRequest(ModelState);

            if (!_ReserveRepository.ReserveExists(ReserveId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ReserveMap = _mapper.Map<Reserves>(updatedReserve);

            if (!_ReserveRepository.UpdateReserve(ReserveMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Reserve");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{ReserveId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReserve(int ReserveId)
        {
            if (!_ReserveRepository.ReserveExists(ReserveId))
            {
                return NotFound();
            }

            var ReserveToDelete = _ReserveRepository.GetReserve(ReserveId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ReserveRepository.DeleteReserve(ReserveToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

        // Added missing delete range of Reserves by a Reserveer **>CK
        

    }
}
