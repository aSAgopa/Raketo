using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities;
using Raketo.Model;
using Raketo.Model.Enums;
using Raketo.DAL.Interfaces;

namespace Raketo.BL.Services
{
    public class UserService : IUserService<UserDto>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> repository, IMapper mapper)
        {
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<bool> AddAsync(UserDto data)
        {
            var user = _mapper.Map<User>(data);
            return await _userRepository.AddAsync(user);

        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(UserTypes user)
        {
            var users = await _userRepository.GetAllAsync(user);
            return _mapper.Map<List<UserDto>>(users);
        }


        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> RegisterUserAsync(string login, string password)
        {
            var user = new User
            {
                Name = login,
                Email = password, 
                Id = Guid.NewGuid()
            };
            return await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> GetByCredentialsAsync(string login, string password)
        {
            var user = await _userRepository.GetByCredentialsAsync(login, password);
            return _mapper.Map<UserDto>(user);
        }

    }
}
