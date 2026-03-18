using Common.Enum;

namespace Common.Dto
{
    public class OrderDto
    {
        public Guid PublicId { get; set; }
        public List<CartItemDto> Items { get; set; } = [];
        public float TotalPrice { get; set; }
        public StatusEnum Status { get; set; }
        public Guid AddressPublicId { get; set; }
    }
}