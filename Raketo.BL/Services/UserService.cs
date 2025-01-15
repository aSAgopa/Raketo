using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities.Interfaces;
using Raketo.DAL.Entities;
using Raketo.Model;
using Raketo.Model.Enums;

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

        public bool Add(UserDto data)
        {
            var user = _mapper.Map<User>(data);
            return _userRepository.Add(user);
            
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<UserDto> GetAll(UserTypes user)
        {
            var users = _userRepository.GetAll(user);
            return _mapper.Map<List<UserDto>>(users);
        }

       
        public UserDto GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }
        
    }
}
