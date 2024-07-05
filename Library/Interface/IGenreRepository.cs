using Library.Domain;
using Library.Dto;

namespace Library.Interface
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        Genre GetGenre(int id);



        bool GenreExists(int id);
        bool CreateGenre(Genre genre);
        bool UpdateGenre( Genre genre);
        bool DeleteGenre(Genre genre);
        bool Save();
        object GetGenreTrimToUpper(GenreDto genreCreate);
    }
}
