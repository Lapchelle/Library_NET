﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
      
        
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        public Genre? Genre { get; set; }

        public string? ImageUrl { get; set; }

        public string? PublishDate { get; set; }

        public string? PublishHouse { get; set; }

        public int? PageCount { get; set; }




       public ICollection<BookCopy> Copy { get; set; }

        public string? Condition {  get; set; } 

        public ICollection<Review> Reviews { get; set; }
    }
}
