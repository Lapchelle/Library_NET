using Library.Domain;

namespace Library.Interface
{
    public interface IRouterRepository
    {
        ICollection<Router> GetRouters();
        Router GetRouter(int RouterId);
        ICollection<Borrow> GetBorrowsByRouter(int RouterId);
        bool RouterExists(int RouterId);
        bool CreateRouter(Router Router);
        bool UpdateRouter(Router Router);
        bool DeleteRouter(Router Router);
        bool Save();
    }
}
