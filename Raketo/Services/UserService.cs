using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL;
using Raketo.Interfaces;
using Raketo.Model;
using Raketo.Model.Enums;
using Raketo.ViewModel;

namespace Raketo.Services
{
    public class UserService : IUsersServiceUI<UserViewModel, UserTypes>
    {
        private readonly IUserService<UserDto> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserService<UserDto> repository, IMapper mapper)
        {
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<bool> AddAsync(UserViewModel data)
        {
            var user = _mapper.Map<UserDto>(data);
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
           await _userRepository.DeleteAsync(id);
        }
        public async Task<IEnumerable<UserViewModel>> GetAllAsync(UserTypes user)
        {
            var users = await _userRepository.GetAllAsync(user);
            return _mapper.Map<List<UserViewModel>>(users);
        }
              
        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task UpdateAsync(UserViewModel data)
        {
            throw new NotImplementedException();
        }
    }
}
