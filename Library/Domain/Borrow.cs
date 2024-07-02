using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public User? User { get; set; }

        [ForeignKey("Router")]
        public int? RouterId { get; set; }

        public Router? Routers { get; set; }

        public DateTime Borrow_Date { get; set; }

        public DateTime Return_Date { get; set; }

        public DateTime Return_Condition { get; set; }


    }
}
