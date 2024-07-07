using AutoMapper;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : Controller
    {
        private readonly IBorrowRepository _BorrowRepository;



        private readonly IMapper _mapper;

        public BorrowController(IBorrowRepository BorrowRepository,

            IMapper mapper)
        {
            _BorrowRepository = BorrowRepository;
            _mapper = mapper;


        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Borrow>))]
        public IActionResult GetBorrows()
        {
            var Borrows = _mapper.Map<List<BorrowDto>>(_BorrowRepository.GetBorrows());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Borrows);
        }

        [HttpGet("{BorrowId}")]
        [ProducesResponseType(200, Type = typeof(Borrow))]
        [ProducesResponseType(400)]
        public IActionResult GetBorrow(int BorrowId)
        {
            if (!_BorrowRepository.BorrowExists(BorrowId))
                return NotFound();

            var Borrow = _mapper.Map<BorrowDto>(_BorrowRepository.GetBorrow(BorrowId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Borrow);
        }







        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBorrow( [FromBody] BorrowDto BorrowCreate)
        {
            if (BorrowCreate == null)
                return BadRequest(ModelState);

            var borrow = _BorrowRepository.GetBorrows()
                .Where(c => c.Desription.Trim().ToUpper() == BorrowCreate.Desription.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (borrow != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BorrowMap = _mapper.Map<Borrow>(BorrowCreate);


            if (!_BorrowRepository.CreateBorrow(BorrowMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }






        [HttpPut("{BorrowId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBorrow(int BorrowId,
             [FromQuery] int genreId,
            [FromBody] BorrowDto updatedBorrow)
        {
            if (updatedBorrow == null)
                return BadRequest(ModelState);

            if (BorrowId != updatedBorrow.Id)
                return BadRequest(ModelState);

            if (!_BorrowRepository.BorrowExists(BorrowId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var BorrowMap = _mapper.Map<Borrow>(updatedBorrow);

            if (!_BorrowRepository.UpdateBorrow(BorrowMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }





        [HttpDelete("{BorrowId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBorrow(int BorrowId)
        {
            if (!_BorrowRepository.BorrowExists(BorrowId))
            {
                return NotFound();
            }


            var BorrowToDelete = _BorrowRepository.GetBorrow(BorrowId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_BorrowRepository.DeleteBorrow(BorrowToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}