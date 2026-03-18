namespace Common.Dto
{
    public class CartItemDto
    {
        public Guid PublicId { get; set; }
        public Guid UserPublicId { get; set; }
        public Guid ProductPublicId { get; set; }
        public string ProductName { get; set; } = "";
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}