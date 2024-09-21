using Data.Books;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Utilities.Enums;

namespace Services.Books
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;
        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetCount()
        {
            return await _context.Books.AsNoTracking().CountAsync();
        }
        public async Task<List<Book>> GetAll(string? title = null, string? author = null, string? price = null,
            DateTime? date = null, int? sortingId = null)
        {
            var books = _context.Books.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(x => x.Title != null && x.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(x => x.Author != null && x.Author.ToLower().Contains(author.ToLower()));
            }

            if (!string.IsNullOrEmpty(price))
            {
                int startingPrice = 0;
                int endingPrice = 0;
                var priceArr = price.Split('-');
                if (priceArr.Length > 0)
                {
                    int.TryParse(priceArr[0], out startingPrice);
                    if (priceArr.Length > 1)
                    {
                        int.TryParse(priceArr[1], out endingPrice);
                    }
                }

                if (startingPrice > 0)
                {
                    books = books.Where(x => x.Price >= startingPrice);
                }

                if (endingPrice > 0)
                {
                    books = books.Where(x => x.Price <= endingPrice);
                }
            }

            if (date != null)
            {
                books = books.Where(x => x.PublicationDate != null && x.PublicationDate.Value.Date == date.Value.Date);
            }

            if (sortingId != null)
            {
                if ((int)SortingType.Title == sortingId)
                {
                    books = books.OrderBy(x => x.Title);
                }
                else if ((int)SortingType.Author == sortingId)
                {
                    books = books.OrderBy(x => x.Author);
                }
                else if ((int)SortingType.Price == sortingId)
                {
                    books = books.OrderBy(x => x.Price);
                }
                else if ((int)SortingType.Date == sortingId)
                {
                    books = books.OrderBy(x => x.PublicationDate);
                }
            }
            else
            {
                books = books.OrderByDescending(x => x.Id);
            }

            return await books.ToListAsync();
        }
        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
