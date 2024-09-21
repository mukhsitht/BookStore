using Api.Dto.Books;
using Api.Managers.Books;
using Microsoft.AspNetCore.Mvc;
using Utilities.Model;

namespace Api.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet, Route("/Book/GetHomePageContent")]
        public async Task<ApiResponseModel<HomePageDto>> GetHomePageContent()
        {
            var response = await _bookManager.GetHomePageContent();
            return response;
        }

        [HttpPost, Route("/Book/GetAll")]
        public async Task<ApiResponseModel<List<BookDto>>> GetBooks([FromBody] SearchBookDto searchBookDto)
        {
            var response = await _bookManager.GetAll(searchBookDto);
            return response;
        }

        [HttpGet, Route("/Book/Get")]
        public async Task<ApiResponseModel<BookDto>> GetBook(int id)
        {
            var response = await _bookManager.GetById(id);
            return response;
        }

        [HttpPost, Route("/Book/Add")]
        public async Task<ApiResponseModel<bool>> AddBook([FromBody] BookDto bookDto)
        {
            var response = await _bookManager.Add(bookDto);
            return response;
        }

        [HttpPut, Route("/Book/Update")]
        public async Task<ApiResponseModel<bool>> UpdateBook([FromBody] BookDto bookDto)
        {
            var response = await _bookManager.Update(bookDto);
            return response;
        }

        [HttpDelete, Route("/Book/Delete")]
        public async Task<ApiResponseModel<bool>> DeleteBook(int id)
        {
            var response = await _bookManager.Delete(id);
            return response;
        }
    }
}
