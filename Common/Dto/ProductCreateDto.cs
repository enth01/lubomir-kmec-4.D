using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class ProductCreateDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Info { get; set; }
        [Required]
        public float Price { get; set; }
        public List<int> Categories { get; set; } = [];
    }
}