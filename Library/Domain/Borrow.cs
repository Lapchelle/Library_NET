using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        public string? Desription { get; set; }

        //[ForeignKey("User")]
        //public Guid? UserId { get; set; }

        //public User? User { get; set; }

        

        public User? User { get; set; }

        
       public ICollection<Book> Books { get; set; }

        public DateTime Borrow_Date { get; set; }

        public string Return_Date { get; set; }

        public string Return_Condition { get; set; }


    }
}
