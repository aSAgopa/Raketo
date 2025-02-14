using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.Models;
using Raketo.Interfaces;
using Raketo.Model;
using Raketo.ViewModel;

namespace Raketo.Services
{
       public class OrderService : IOrderService<OrderViewModel>
    {
        private readonly IOrderServiceBL<OrderDto> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderServiceBL<OrderDto> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAsync(OrderViewModel data)
        {
            var order = _mapper.Map<OrderDto>(data);
            await _orderRepository.AddAsync(order);
        }

        

        public async Task DeleteAsync(Guid id)
        {
           await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync(Guid userId)
        {
            var orders = await _orderRepository.GetAllAsync(userId);
            return _mapper.Map<List<OrderViewModel>>(orders);

        }

        public async Task<OrderViewModel> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderViewModel>(order);
        }
        public async Task DeleteAllOrdersAsync(Guid userId)
        {
            await _orderRepository.DeleteAllOrdersAsync(userId);
        }
        public async Task<bool> SendCustomerBankInfoAsync(CustomerBankInfo customerBankInfo) 
        {
            var result = _mapper.Map<CustomerBankInfoDto>(customerBankInfo);
            return await _orderRepository.SendInfoToBankAsync(result);
        }
        

    }
}
