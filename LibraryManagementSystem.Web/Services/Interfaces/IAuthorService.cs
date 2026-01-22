using LibraryManagementSystem.Web.Models;

namespace LibraryManagementSystem.Web.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> CreateAsync(Author author, CancellationToken cancellationToken = default);
        Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
