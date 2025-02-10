
namespace Raketo.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        //public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
