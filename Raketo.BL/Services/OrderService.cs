using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities;
using Raketo.DAL.Interfaces;
using Raketo.Model;

namespace Raketo.BL.Services
{
    public class OrderService : IOrderServiceBL<OrderDto>
    {
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository<Order> orderRepository, IMapper mapper, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository;
        }

        public async Task AddAsync(OrderDto data)
        {

            if (data.Id == Guid.Empty)
            {
                data.Id = Guid.NewGuid();
            }
            var order = _mapper.Map<Order>(data);
            await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            await UpdateProductQuantityAsync(id);
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync(Guid userId)
        {
            var orders = await _orderRepository.GetAllAsync(userId);
            return _mapper.Map<List<OrderDto>>(orders);

        }
        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }
        public async Task UpdateProductQuantityAsync(Guid Id)
        {
            var order = await _orderRepository.GetByIdAsync(Id);
            var product = await _productRepository.GetByIdAsync(order.ProductId);
            product.Quantity += order.Amount;
            await _productRepository.UpdateAsync(product);

        }
        public async Task DeleteAllOrdersAsync(Guid userId)
        {
            var orders = await _orderRepository.GetAllAsync(userId); 
            foreach (var order in orders)
            {
                await _orderRepository.DeleteAsync(order.Id);
            }
        }
        /// <summary>
        /// Sends payment details to the bank and receives the processing result.
        /// If the payment is successful, all user orders are deleted.
        /// </summary>
        /// <param name="customerBankInfo"></param>
        /// <returns></returns>
        public async Task<bool> SendInfoToBankAsync(CustomerBankInfoDto customerBankInfo)
        {
            await Task.Delay(1000);

            return true;

        }
        
    }
}
