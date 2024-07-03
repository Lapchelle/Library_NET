using Library.Domain;
using Library.Dto;
using System.Diagnostics;

namespace Library.Repository
{
    public interface IBorrowRepository
    {
        ICollection<Borrow> GetBorrows();
        Borrow GetBorrow(int id);

        public  Task<IEnumerable<Borrow>> GetAllBorrowsByRouter(string name);

        bool BorrowExists(int id);
        bool CreateBorrow( Borrow Borrow);
        bool UpdateBorrow(int user_id, int router_id, Borrow Borrow);
        bool DeleteBorrow(Borrow borrow);
        bool Save();
    }
}
