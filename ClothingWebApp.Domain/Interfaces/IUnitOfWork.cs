namespace ClothingWebApp.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IProductRepository Products { get; }
        IUserRoleRepository UserRoles { get; }
        

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }

}
