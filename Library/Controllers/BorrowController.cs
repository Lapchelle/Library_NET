using AutoMapper;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [Route("api/[controller]")]
    public class BorrowController : Controller
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IMapper _mapper;


    }
}
