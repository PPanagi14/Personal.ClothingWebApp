using ClothingWebApp.Domain.Interfaces;
using ClothingWebApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingWebApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
            {
                throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} was not found.");
            }
            return entity;
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
    }

}
