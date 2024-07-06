using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BookCopyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Condition { get; set; }

        

        public int? BookId { get; set; }
    }
}
