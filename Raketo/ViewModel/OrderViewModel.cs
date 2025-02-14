
namespace Raketo.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!; 
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public decimal Price {  get; set; }
        public Guid ProductId { get; set; }
      
    }
}
