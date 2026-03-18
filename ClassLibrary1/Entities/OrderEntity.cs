using Common.Enum;

namespace ClassLibrary1.Entities
{
    public class OrderEntity : BaseEntity 
    {
        public required List<CartItemEntity> Items { get; set; }
        public float TotalPrice { get; set; }
        public int AddressId { get; set; }
        public required UserAddressEntity Address { get; set; }
        public StatusEnum Status { get; set; }
        public Guid UserPublicId { get; set; }
    }
}
