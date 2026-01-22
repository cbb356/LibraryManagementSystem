using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models;
using LibraryManagementSystem.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> CreateAsync(Book book, CancellationToken cancellationToken = default)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            var author = await _dbContext.Authors.FindAsync(new object[] { book.AuthorId }, cancellationToken);
            if (author == null) throw new InvalidOperationException($"Author with id {book.AuthorId} does not exist.");

            // Set available quantity initially equal to quantity if not set
            if (book.AvailableQuantity <= 0)
            {
                book.AvailableQuantity = book.Quantity;
            }

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book;
        }

        public Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books.Include(b => b.Author).ToListAsync(cancellationToken);
        }
    }
}
