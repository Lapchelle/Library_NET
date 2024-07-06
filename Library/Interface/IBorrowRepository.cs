using Library.Domain;
using Library.Dto;
using System.Diagnostics;

namespace Library.Repository
{
    public interface IBorrowRepository
    {
        ICollection<Borrow> GetBorrows();
        Borrow GetBorrow(int id);



        bool BorrowExists(int id);
        bool CreateBorrow(Borrow Borrow);
        bool UpdateBorrow(Borrow Borrow);
        bool DeleteBorrow(Borrow Borrow);
        bool Save();
        
    }
}
