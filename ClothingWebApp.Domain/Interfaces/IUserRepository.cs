using ClothingWebApp.Domain.Entities;

namespace ClothingWebApp.Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
       
    }
}
