using Common.Enum;

namespace Common.Dto
{
    public class UserDto
    {
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public RoleEnum Role { get; set; }
    }
}