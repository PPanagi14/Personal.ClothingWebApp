using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using ClothingWebApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Infrastructure.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public AppDbContext _context;
        public UserRoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetUserRolesByUserId(long id)
        {
            var roles = await _context.UserRoles
            .Where(x => x.UserId == id)
            .Include(x => x.Role) 
            .Select(x => x.Role) 
            .ToListAsync();

            return roles; 
        }
    }
}
