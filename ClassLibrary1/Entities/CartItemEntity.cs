using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class CartItemEntity : BaseEntity
    {
        public required int ProductId { get; set; }

        public required ProductEntity Product { get; set; }

        public required int Quantity { get; set; }

        public required Guid UserId { get; set; }

    }
}
