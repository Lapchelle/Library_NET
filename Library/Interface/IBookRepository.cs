using Library.Domain;
using Library.Dto;

namespace Library.Interface
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);

        decimal GetBookRating(int bookId);

        bool BookExists(int id);
        bool CreateBook( Book Book);
        bool UpdateBook( Book Book);
        bool DeleteBook(Book Book);
        bool Save();
        object GetBookTrimToUpper(BookDto bookCreate);
    }
}
