using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class UserCreateDto
    {
        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(4)]
        public required string Password { get; set; }
    }
}
