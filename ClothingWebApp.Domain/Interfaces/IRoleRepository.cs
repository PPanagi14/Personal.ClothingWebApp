using ClothingWebApp.Domain.Entities;

namespace ClothingWebApp.Domain.Interfaces
{
    public interface IRoleRepository:IRepository<Role>
    {
        Task<Role> GetByNameAsync(string roleName);
    }
}
