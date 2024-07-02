using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Address
    {
        [Key]

        public int Id { get; set; }
        public string? Street { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
    }
}
