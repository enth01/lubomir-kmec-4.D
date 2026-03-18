namespace ClassLibrary1.Entities
{
    public class ProductEntity : BaseEntity
    {

        public required string Name { get; set; }

        public required string Info { get; set; }

        public required List<int> Categories { get; set; } = [];

        public float Price { get; set; }
    }
}
