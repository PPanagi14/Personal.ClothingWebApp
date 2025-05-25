using ClothingWebApp.Domain.Common;
using ClothingWebApp.Domain.Enums;

namespace ClothingWebApp.Domain.Entities
{
    public class Role:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();


    }
}
