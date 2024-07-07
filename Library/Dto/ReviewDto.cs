using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        
        

        public int BookId { get; set; }
        
    }
}
