using Api.Dto.Books;
using Utilities.Model;

namespace Api.Managers.Books
{
    public interface IBookManager
    {
        Task<ApiResponseModel<HomePageDto>> GetHomePageContent();
        Task<ApiResponseModel<List<BookDto>>> GetAll(SearchBookDto searchBookDto);
        Task<ApiResponseModel<BookDto>> GetById(int id);
        Task<ApiResponseModel<bool>> Add(BookDto bookDto);
        Task<ApiResponseModel<bool>> Update(BookDto bookDto);
        Task<ApiResponseModel<bool>> Delete(int id);
    }
}
