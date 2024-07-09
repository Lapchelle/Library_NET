using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BorrowDto
    {
        public int Id { get; set; }

        public string? Desription { get; set; }

       
        public int? CopyId { get; set; }

       


       
        public string? UserId { get; set; }

       





        public DateTime Borrow_Date { get; set; }

        public string Return_Date { get; set; }

        public string Return_Condition { get; set; }
    }
}
