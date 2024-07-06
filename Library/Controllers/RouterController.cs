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
    public class RouterController : Controller
    {
        private readonly IBorrowRepository _borrowRepository;

        private readonly IRouterRepository _RouterRepository;

        private readonly IMapper _mapper;

        public RouterController(IBorrowRepository borrowRepository, IRouterRepository RouterRepository,

            IMapper mapper)
        {
            _borrowRepository = borrowRepository;
            _mapper = mapper;

            _RouterRepository = RouterRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Router>))]
        public IActionResult GetRouters()
        {
            var Routers = _mapper.Map<List<RouterDto>>(_RouterRepository.GetRouters());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Routers);
        }

        [HttpGet("{RouterId}")]
        [ProducesResponseType(200, Type = typeof(Router))]
        [ProducesResponseType(400)]
        public IActionResult GetRouter(int RouterId)
        {
            if (!_RouterRepository.RouterExists(RouterId))
                return NotFound();

            var Router = _mapper.Map<RouterDto>(_RouterRepository.GetRouter(RouterId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Router);
        }

        [HttpGet("{RouterId}/borrows")]
        public IActionResult GetReviewsByARouter(int RouterId)
        {
            if (!_RouterRepository.RouterExists(RouterId))
                return NotFound();

            var borrows = _mapper.Map<List<BorrowDto>>(
                _RouterRepository.GetBorrowsByRouter(RouterId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(borrows);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRouter([FromBody] RouterDto RouterCreate)
        {
            if (RouterCreate == null)
                return BadRequest(ModelState);

            var country = _RouterRepository.GetRouters()
                .Where(c => c.LastName.Trim().ToUpper() == RouterCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var RouterMap = _mapper.Map<Router>(RouterCreate);

            if (!_RouterRepository.CreateRouter(RouterMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{RouterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRouter(int RouterId, [FromBody] RouterDto updatedRouter)
        {
            if (updatedRouter == null)
                return BadRequest(ModelState);

            if (RouterId != updatedRouter.Id)
                return BadRequest(ModelState);

            if (!_RouterRepository.RouterExists(RouterId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var RouterMap = _mapper.Map<Router>(updatedRouter);

            if (!_RouterRepository.UpdateRouter(RouterMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{RouterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRouter(int RouterId)
        {
            if (!_RouterRepository.RouterExists(RouterId))
            {
                return NotFound();
            }

            var RouterToDelete = _RouterRepository.GetRouter(RouterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_RouterRepository.DeleteRouter(RouterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Router");
            }

            return NoContent();
        }
    }
}
