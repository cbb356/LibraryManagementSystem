using LibraryManagementSystem.Web.Models;

namespace LibraryManagementSystem.Web.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> CreateAsync(Book book, CancellationToken cancellationToken = default);
        Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
