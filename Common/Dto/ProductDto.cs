namespace Common.Dto
{
    public class ProductDto
    {
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public required string Info { get; set; }
        public float Price { get; set; }
        public List<int> Categories { get; set; } = [];
    }
}
