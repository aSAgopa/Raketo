using Raketo.Model.Enums;

namespace Raketo.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public UserTypes UserType { get; set; }
        
        //public ICollection<Order> Orders { get; set; }
    }
}