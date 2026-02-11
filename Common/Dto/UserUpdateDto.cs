using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class UserUpdateDto
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(4)]
        public string? Password { get; set; }
    }
}
