using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class ReservesDto
    {
        public int Id { get; set; }

        public DateOnly reserveTime { get; set; }

        public DateOnly endOfReserveTime { get; set; }

       
        public int? BookCopyId { get; set; }

      
    }
}
