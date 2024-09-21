namespace Api.Dto.Books
{
    public class SearchBookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Price { get; set; }
        public string? Date { get; set; }
        public int? SortingId { get; set; }
    }
}
