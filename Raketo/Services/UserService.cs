using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities;
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
        
        public async Task<bool> RegisterUserAsync(string login, string password)
        {
          return await _userRepository.RegisterUserAsync(login, password);
        }
        public async Task<UserViewModel> GetByCredentialsAsync(string login, string password)
        {
          var user = await _userRepository.GetByCredentialsAsync(login, password);
          return _mapper.Map<UserViewModel>(user);
        }


    }
}
