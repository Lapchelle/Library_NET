﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class BookCopy
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int Count_Free { get; set; }

        public string Condition { get; set; }

        [ForeignKey("Book")]

        public int? BookId { get; set; }

        public Book? Book { get; set; }

        public ICollection<Borrow> Borrows { get; set; }

        public ICollection<Reserves> Reserves { get; set; }
    }
}
