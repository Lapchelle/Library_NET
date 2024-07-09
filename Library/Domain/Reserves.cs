using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Reserves
    {
        public int Id { get; set; }

        public DateOnly reserveTime { get; set; }

        public DateOnly endOfReserveTime { get; set; }

        [ForeignKey("BookCopy")]
        public int? BookCopyId { get; set; }

        public BookCopy? BookCopy { get; set; }
    }
}
