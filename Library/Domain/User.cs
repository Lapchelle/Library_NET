using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserImageURL { get; set; }

        public string Login {  get; set; }  

        public string Password { get; set; }

        public string Email { get; set; }

        [ForeignKey("Address")]

        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public ICollection<Book> Books { get; set; }

        
    }
}
