using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BorrowDto
    {
        public int Id { get; set; }

        public string? Desription { get; set; }

        //[ForeignKey("User")]
        //public Guid? UserId { get; set; }

        //public User? User { get; set; }



      


        

        public DateTime Borrow_Date { get; set; }

        public string Return_Date { get; set; }

        public string Return_Condition { get; set; }
    }
}
