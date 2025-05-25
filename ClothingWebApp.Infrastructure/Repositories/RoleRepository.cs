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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "AppDbContext cannot be null.");
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Role name cannot be null or empty.", nameof(roleName));
            // Use case-insensitive comparison to find the role by name 
            var role = await _context.Roles
                .Where(r =>r.Name==roleName).FirstOrDefaultAsync();
                
            if (role == null)
            {
                throw new InvalidOperationException($"Role with name '{roleName}' not found.");
            }

                return role ;
        }
    }
}
