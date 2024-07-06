using Library.Domain;
using Library.Dto;

namespace Library.Interface
{
    public interface IBookCopyRepository
    {
        ICollection<BookCopy> GetBookCopys();
        BookCopy GetBookCopy(int id);

        ICollection<Borrow> GetBorrowsByBookCopy(int CopyId);

        bool BookCopyExists(int id);
        bool CreateBookCopy( BookCopy BookCopy);
        bool UpdateBookCopy( BookCopy BookCopy);
        bool DeleteBookCopy(BookCopy BookCopy);
        bool Save();
        object GetBookCopyTrimToUpper(BookCopyDto BookCopyCreate);
    }
}
