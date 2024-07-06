using AutoMapper;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopyController : Controller
    {
        private readonly IBookCopyRepository _BookCopyRepository;

        

        private readonly IMapper _mapper;

        public BookCopyController(IBookCopyRepository bookcopyRepository,

            IMapper mapper)
        {
            _BookCopyRepository = bookcopyRepository;
            _mapper = mapper;

            
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookCopy>))]
        public IActionResult GetBookCopys()
        {
            var BookCopys = _mapper.Map<List<BookCopyDto>>(_BookCopyRepository.GetBookCopys());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(BookCopys);
        }

        [HttpGet("{BookCopyId}")]
        [ProducesResponseType(200, Type = typeof(BookCopy))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int BookCopyId)
        {
            if (!_BookCopyRepository.BookCopyExists(BookCopyId))
                return NotFound();

            var BookCopy = _mapper.Map<BookCopyDto>(_BookCopyRepository.GetBookCopy(BookCopyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(BookCopy);
        }

        [HttpGet("{BookCopyId}/borrows")]
        public IActionResult GetBorrowsByABookCopy(int BookCopyId)
        {
            if (!_BookCopyRepository.BookCopyExists(BookCopyId))
                return NotFound();

            var books = _mapper.Map<List<BookDto>>(
                _BookCopyRepository.GetBorrowsByBookCopy(BookCopyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBookCopy([FromBody] BookCopyDto BookCopyCreate)
        {
            if (BookCopyCreate == null)
                return BadRequest(ModelState);

            var country = _BookCopyRepository.GetBookCopys()
                .Where(c => c.Name.Trim().ToUpper() == BookCopyCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BookCopyMap = _mapper.Map<BookCopy>(BookCopyCreate);

            if (!_BookCopyRepository.CreateBookCopy(BookCopyMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{BookCopyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBookCopy(int BookCopyId, [FromBody] BookCopyDto updatedBookCopy)
        {
            if (updatedBookCopy == null)
                return BadRequest(ModelState);

            if (BookCopyId != updatedBookCopy.Id)
                return BadRequest(ModelState);

            if (!_BookCopyRepository.BookCopyExists(BookCopyId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var BookCopyMap = _mapper.Map<BookCopy>(updatedBookCopy);

            if (!_BookCopyRepository.UpdateBookCopy(BookCopyMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{BookCopyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBookCopy(int BookCopyId)
        {
            if (!_BookCopyRepository.BookCopyExists(BookCopyId))
            {
                return NotFound();
            }

            var BookCopyToDelete = _BookCopyRepository.GetBookCopy(BookCopyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_BookCopyRepository.DeleteBookCopy(BookCopyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting BookCopy");
            }

            return NoContent();
        }


    }
}
