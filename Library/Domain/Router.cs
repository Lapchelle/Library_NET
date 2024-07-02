using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Router
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("Address")]

        public int? AddressId { get; set; }

        public Address Address { get; set; }

        public int ContactNumber { get; set; }  

        public ICollection<Borrow> Borrows { get; set; }
    }
}
