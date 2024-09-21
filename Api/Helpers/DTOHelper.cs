using Api.Dto.Books;
using AutoMapper;
using Data.Books;

namespace Api.Helpers
{
    public class DTOHelper : IDTOHelper
    {
        private readonly IMapper _mapper;
        public DTOHelper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public BookDto PrepareBookDto(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);

            bookDto.FormattedPrice = string.Format("{0:0.000}", book.Price) + " KWD";
            bookDto.FormattedPublicationDate = book.PublicationDate?.ToString("dd/MM/yyyy");

            return bookDto;
        }
    }
}
