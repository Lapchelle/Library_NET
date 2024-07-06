using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Dto;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private PostgresContext _context;
        private readonly IMapper _mapper;
        public BorrowRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public bool BorrowExists(int id)
        {
            return _context.Borrows.Any(c => c.Id == id);
        }

        

        public bool CreateBorrow( Borrow Borrow)
        {
           

            _context.Add(Borrow);

            return Save();
        }

        public bool DeleteBorrow(Borrow borrow)
        {
            _context.Remove(borrow);
            return Save();
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsByRouter(string name)
        {
            return await _context.Borrows.Where(c => c.Router.FirstName.Contains(name)).ToListAsync();
        }

        public Borrow GetBorrow(int id)
        {
            return _context.Borrows.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Borrow> GetBorrows()
        {
            return _context.Borrows.OrderBy(p => p.Id).ToList();
        }

       

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

       

        public bool UpdateBorrow( Borrow Borrow)
        {
            _context.Update(Borrow);
            return Save();
        }
    }
}
