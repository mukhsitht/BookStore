using Data.Books;

namespace Services.Books
{
    public interface IBookService
    {
        Task<int> GetCount();
        Task<List<Book>> GetAll(string? title = null, string? author = null, string? price = null,
            DateTime? date = null, int? sortingId = null);
        Task<Book?> GetById(int id);
        Task Add(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}
