using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BookCopyDto
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int Count_Free { get; set; }

        public string Condition { get; set; }

       

        public int? BookId { get; set; }

       

    }
}
