using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class CartItemCreateDto
    {
        [Required]
        public Guid UserPublicId { get; set; }
        [Required]
        public Guid ProductPublicId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}