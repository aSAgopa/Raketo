
namespace Raketo.Model
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } 
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }

    }
}
