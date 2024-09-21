using Api.Dto.Books;
using Data.Books;

namespace Api.Helpers
{
    public interface IDTOHelper
    {
        BookDto PrepareBookDto(Book book);
    }
}
