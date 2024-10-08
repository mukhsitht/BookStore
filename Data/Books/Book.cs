﻿using System.ComponentModel.DataAnnotations;

namespace Data.Books
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
