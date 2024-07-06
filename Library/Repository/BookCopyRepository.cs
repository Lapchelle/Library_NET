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

        public object GetBookCopyTrimToUpper(BookCopyDto BookCopyCreate)
        {
            return GetBookCopys().Where(c => c.Name.Trim().ToUpper() == BookCopyCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public ICollection<Borrow> GetBorrowsByBookCopy(int CopyId)
        {
            return _context.Borrows.Where(e => e.CopyId == CopyId).ToList();
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
