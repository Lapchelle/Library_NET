using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Dto;
using Library.Interface;

namespace Library.Repository
{
    public class BookCopyRepository : IBookCopyRepository
    {

        private PostgresContext _context;
        private readonly IMapper _mapper;

        public BookCopyRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool BookCopyExists(int id)
        {
            return _context.BookCopies.Any(c => c.Id == id);
        }

        public bool CreateBookCopy(BookCopy BookCopy)
        {
            _context.Add(BookCopy);

            return Save();
        }

        public bool DeleteBookCopy(BookCopy BookCopy)
        {
            _context.Remove(BookCopy);

            return Save();
        }

        public BookCopy GetBookCopy(int id)
        {
            return _context.BookCopies.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<BookCopy> GetBookCopys()
        {
            return _context.BookCopies.OrderBy(p => p.Id).ToList();
        }

       
        public ICollection<Borrow> GetBorrowsByBookCopy(int BookCopyId)
        {
            return _context.Borrows.Where(e => e.CopyId == BookCopyId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBookCopy(BookCopy BookCopy)
        {
            _context.Update(BookCopy);
            return Save();
        }
    }
}
