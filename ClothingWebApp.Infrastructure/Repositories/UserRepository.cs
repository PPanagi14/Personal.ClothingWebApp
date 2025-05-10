using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using ClothingWebApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingWebApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync()
                   ?? throw new InvalidOperationException($"User with email '{email}' not found.");
        }
    }
}
