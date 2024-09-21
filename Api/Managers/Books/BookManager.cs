using Api.Dto.Books;
using Api.Helpers;
using AutoMapper;
using Data.Books;
using Services.Books;
using Utilities.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Managers.Books
{
    public class BookManager : IBookManager
    {
        private readonly ILogger<BookManager> _logger;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IDTOHelper _dtoHelper;
        public BookManager(ILogger<BookManager> logger,
            IMapper mapper,
            IBookService bookService,
            IDTOHelper dtoHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _bookService = bookService;
            _dtoHelper = dtoHelper;
        }
        public async Task<ApiResponseModel<HomePageDto>> GetHomePageContent()
        {
            var response = new ApiResponseModel<HomePageDto>();

            try
            {
                var homePageDto = new HomePageDto();
                homePageDto.TotalBooks = await _bookService.GetCount();

                response.Data = homePageDto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<List<BookDto>>> GetAll(SearchBookDto searchBookDto)
        {
            var response = new ApiResponseModel<List<BookDto>>();

            try
            {
                var books = await _bookService.GetAll(title: searchBookDto.Title, author: searchBookDto.Author,
                    price: searchBookDto.Price, date: ConvertStringToDate(searchBookDto.Date), sortingId: searchBookDto.SortingId);

                var bookDtos = new List<BookDto>();
                foreach (var book in books)
                {
                    var bookDto = _dtoHelper.PrepareBookDto(book);
                    bookDtos.Add(bookDto);
                }

                response.Data = bookDtos;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<BookDto>> GetById(int id)
        {
            var response = new ApiResponseModel<BookDto>();

            try
            {
                var book = await _bookService.GetById(id);
                if (book == null)
                {
                    response.Message = "Book not exist";
                    return response;
                }

                var bookDto = _dtoHelper.PrepareBookDto(book);
                response.Data = bookDto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<bool>> Add(BookDto bookDto)
        {
            var response = new ApiResponseModel<bool>();

            try
            {
                if (bookDto.Price <= 0)
                {
                    response.Message = "Price should be greater than zero";
                    return response;
                }

                var book = _mapper.Map<Book>(bookDto);
                book.PublicationDate = ConvertStringToDate(bookDto.FormattedPublicationDate);
                await _bookService.Add(book);

                response.Message = "Successfully Added";
                response.Data = true;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<bool>> Update(BookDto bookDto)
        {
            var response = new ApiResponseModel<bool>();

            try
            {
                if (bookDto.Price <= 0)
                {
                    response.Message = "Price should be greater than zero";
                    return response;
                }

                var book = await _bookService.GetById(bookDto.Id);
                if (book == null)
                {
                    response.Message = "Book not exist";
                    return response;
                }

                book.Title = bookDto.Title;
                book.Author = bookDto.Author;
                book.Price = bookDto.Price;
                book.PublicationDate = ConvertStringToDate(bookDto.FormattedPublicationDate);
                await _bookService.Update(book);

                response.Message = "Successfully Updated";
                response.Data = true;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<bool>> Delete(int id)
        {
            var response = new ApiResponseModel<bool>();

            try
            {
                var book = await _bookService.GetById(id);
                if (book == null)
                {
                    response.Message = "Book not exist";
                    return response;
                }

                await _bookService.Delete(book);

                response.Message = "Successfully Deleted";
                response.Data = true;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        private DateTime? ConvertStringToDate(string? date)
        {
            try
            {
                if (string.IsNullOrEmpty(date))
                {
                    return null;
                }

                var arrDate = date.Split('/');
                if (arrDate.Length != 3)
                {
                    return null;
                }

                int.TryParse(arrDate[0], out int day);
                int.TryParse(arrDate[1], out int month);
                int.TryParse(arrDate[2], out int year);

                return new DateTime(year, month, day);
            }
            catch
            {
                return null;
            }
        }
    }
}
