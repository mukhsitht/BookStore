namespace Api.Dto.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public string? FormattedPrice { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? FormattedPublicationDate { get; set; }
    }
}
