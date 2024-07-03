using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BorrowDto
    {
        public int Id { get; set; }

        

        public DateTime Borrow_Date { get; set; }

        public DateTime Return_Date { get; set; }

        public DateTime Return_Condition { get; set; }
    }
}
