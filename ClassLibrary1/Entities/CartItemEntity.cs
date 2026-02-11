using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities
{
    public class CartItemEntity : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }

        public required ProductEntity Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Guid UserId { get; set; }

    }
}
