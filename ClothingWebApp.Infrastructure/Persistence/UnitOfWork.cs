using ClothingWebApp.Application.Services;
using ClothingWebApp.Domain.Common;
using ClothingWebApp.Domain.Entities;
using ClothingWebApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ClothingWebApp.Infrastructure.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;


        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IProductRepository Products { get; }
        public IUserRoleRepository UserRoles { get; }

        public UnitOfWork(AppDbContext context,IUserRoleRepository userRole,IUserRepository user,IRoleRepository role,IProductRepository product,ICurrentUserService currentUser)
        {
            _context = context;
            Users = user;
            Roles = role;
            Products = product;
            UserRoles = userRole;
            _currentUser = currentUser;
        }



        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            var entries = _context.ChangeTracker
                .Entries<BaseEntity>();

            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.PublicId = Guid.NewGuid();
                    entry.Entity.CreatedAt = utcNow;
                    entry.Entity.CreatedBy = _currentUser.UserId;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = utcNow;
                    entry.Entity.UpdatedBy = _currentUser.UserId;
                }
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }

      
    }
}
