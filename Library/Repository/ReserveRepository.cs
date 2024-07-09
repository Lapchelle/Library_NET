using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Interface;

namespace Library.Repository
{
    public class ReserveRepository : IReserveRepository
    {
        private PostgresContext _context;
        private readonly IMapper _mapper;
        public ReserveRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public bool CreateReserve(Reserves Reserve)
        {
            _context.Add(Reserve);
            return Save();
        }

        public bool DeleteReserve(Reserves Reserve)
        {
            _context.Remove(Reserve);
            return Save();
        }

        public Reserves GetReserve(int id)
        {
            return _context.Reserves.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Reserves> GetReserveByBookCopy(int CopyId)
        {
            return _context.Reserves.Where(r => r.BookCopy.Id == CopyId).ToList();
        }

        public ICollection<Reserves> GetReserves()
        {
            return _context.Reserves.ToList();
        }

        public bool ReserveExists(int id)
        {
            return _context.Reserves.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReserve(Reserves Reserve)
        {
            _context.Update(Reserve);
            return Save();
        }
    }
}
