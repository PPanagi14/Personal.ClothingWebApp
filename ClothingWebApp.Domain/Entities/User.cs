using ClothingWebApp.Domain.Common;

namespace ClothingWebApp.Domain.Entities
{
    public class User: BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        // Navigation properties
        //public ICollection<Order> Orders { get; set; }
        //public ICollection<Cart> Carts { get; set; }
        //public ICollection<UserRole> UserRoles { get; set; }
    }
}
