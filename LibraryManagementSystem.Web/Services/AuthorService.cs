using LibraryManagementSystem.Web.Data;
using LibraryManagementSystem.Web.Models;
using LibraryManagementSystem.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Web.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> CreateAsync(Author author, CancellationToken cancellationToken = default)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));

            await _dbContext.Authors.AddAsync(author, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return author;
        }
        public Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Authors.Include(a => a.Books).ToListAsync(cancellationToken);
        }

    }
}
