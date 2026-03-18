using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class OrderCreateDto
    {
        [Required]
        public Guid UserPublicId { get; set; }
        [Required]
        public Guid AddressPublicId { get; set; }
    }
}