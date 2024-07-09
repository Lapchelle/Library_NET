using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        public string? Desription { get; set; }

        [ForeignKey("BookCopy")]
        public int? CopyId { get; set; }

        public BookCopy? BookCopy { get; set; }


        [ForeignKey("User")]
        public string? UserId { get; set; }

        public User? User { get; set; }





        public DateTime Borrow_Date { get; set; }

        public string Return_Date { get; set; }

        public string Return_Condition { get; set; }


    }
}
