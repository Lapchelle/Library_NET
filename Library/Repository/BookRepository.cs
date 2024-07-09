using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Dto;
using Library.Interface;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private PostgresContext _context;
        private readonly IMapper _mapper;

        public BookRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool BookExists(int id)
        {
            return _context.Books.Any(c => c.Id == id);
        }

        public bool CreateBook( Book Book)
        {

            _context.Add(Book);

            return Save();
        }

        public bool DeleteBook(Book Book)
        {
            _context.Remove(Book);
            return Save();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(p => p.Id).ToList();
        }

        public object GetBookTrimToUpper(BookDto bookCreate)
        {
            return GetBooks().Where(c => c.Title.Trim().ToUpper() == bookCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(Book Book)
        {
            _context.Update(Book);
            return Save();
        }

        public decimal GetBookRating(int bookId)
        {
            var review = _context.Reviews.Where(p => p.Book.Id == bookId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }
    }
}
