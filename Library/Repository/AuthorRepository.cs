using AutoMapper;
using Library.Data;
using Library.Domain;
using Library.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        private PostgresContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public bool AuthorExists(int authorId)
        {
            return _context.Authors.Any(r => r.Id == authorId);
        }

        public bool CreateAuthor(Author author)
        {
            _context.Add(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);
            return Save();
        }

        public Author GetAuthor(int authorId)
        {
            return _context.Authors.Where(r => r.Id == authorId).Include(e => e.Books).FirstOrDefault();
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books.Where(r => r.Author.Id == authorId).ToList();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAuthor(Author author)
        {
            _context.Update(author);
            return Save();
        }
    }
}
