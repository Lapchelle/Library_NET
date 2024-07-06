﻿using AutoMapper;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private readonly IGenreRepository _genreRepository;

        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IGenreRepository genreRepository,
            
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;

            _genreRepository = genreRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var Book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Book);
        }

        [HttpGet("{bookId}/bookcopies")]
        public IActionResult GetBookCopiesByBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var books = _mapper.Map<List<BookCopyDto>>(
                _bookRepository.GetBookCopiesByBook(bookId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }






        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook( [FromQuery] int genreId, [FromBody] BookDto bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);

            var books = _bookRepository.GetBookTrimToUpper(bookCreate);

            if (books != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(bookCreate);
            

            if (!_bookRepository.CreateBook(genreId,bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }





        [Authorize(Roles = "Admin")]
        [HttpPut("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int bookId,
             [FromQuery] int genreId,
            [FromBody] BookDto updatedBook)
        {
            if (updatedBook == null)
                return BadRequest(ModelState);

            if (bookId != updatedBook.Id)
                return BadRequest(ModelState);

            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var BookMap = _mapper.Map<Book>(updatedBook);

            if (!_bookRepository.UpdateBook( genreId, BookMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }




        [Authorize(Roles = "Admin")]
        [HttpDelete("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            
            var BookToDelete = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if (!_bookRepository.DeleteBook(BookToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
