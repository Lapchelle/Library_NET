using Library.Domain;

namespace Library.Interface
{
    public interface IReserveRepository
    {
        ICollection<Reserves> GetReserves();
        Reserves GetReserve(int id);

        ICollection<Reserves> GetReserveByBookCopy(int CopyId);

        bool ReserveExists(int id);
        bool CreateReserve(Reserves Reserve);
        bool UpdateReserve(Reserves Reserve);
        bool DeleteReserve(Reserves Reserve);
        bool Save();
    }
}
