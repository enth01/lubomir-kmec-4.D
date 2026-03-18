namespace Common.Dto
{
    public class ProductUpdateDto
    {
        public Guid PublicId { get; set; }
        public string? Name { get; set; }
        public string? Info { get; set; }
        public float? Price { get; set; }
        public List<int>? Categories { get; set; }
    }
}