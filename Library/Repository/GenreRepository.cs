using Library.Data;
using Library.Domain;
using Library.Dto;
using Library.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class GenreRepository : IGenreRepository
    {

        private PostgresContext _context;

        public GenreRepository(PostgresContext context)
        {
            _context = context;
        }
        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
        }

        public bool DeleteGenre(Genre genre)
        {
            _context.Remove(genre);
            return Save();
        }

        public bool GenreExists(int id)
        {
            return _context.Genres.Any(c => c.Id == id);
        }

        public object GetGenreTrimToUpper(GenreDto genreCreate)
        {
            return GetGenres().Where(c => c.Name.Trim().ToUpper() == genreCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGenre(Genre genre)
        {
            _context.Update(genre);
            return Save();
        }

        public ICollection<Book> GetBookByGenre(int genreId)
        {
            return _context.Book_Genres.Where(e => e.GenreId == genreId).Select(c => c.Book).ToList();
        }
    }
}
