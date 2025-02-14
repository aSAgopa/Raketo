using Raketo.Model.Enums;

namespace Raketo.Model
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserTypes UserType { get; set; }
    }
}
