using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class RouterRepository : IRouterRepository
    {

        private PostgresContext _context;
        private readonly IMapper _mapper;

        public RouterRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateRouter(Router Router)
        {
            _context.Add(Router);
            return Save();
            
        }

        public bool DeleteRouter(Router Router)
        {
            _context.Remove(Router);
            return Save();
        }

        public ICollection<Borrow> GetBorrowsByRouter(int RouterId)
        {
            return _context.Borrows.Where(r => r.Router.Id == RouterId).ToList() ;
        }

        public Router GetRouter(int RouterId)
        {
            return _context.Routers.Where(r => r.Id == RouterId).Include(e => e.Borrows).FirstOrDefault();
        }

        public ICollection<Router> GetRouters()
        {
            return _context.Routers.ToList();
        }

        public bool RouterExists(int RouterId)
        {
            return _context.Routers.Any(r => r.Id == RouterId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRouter(Router Router)
        {
            _context.Update(Router);
            return Save();
        }
    }
}
