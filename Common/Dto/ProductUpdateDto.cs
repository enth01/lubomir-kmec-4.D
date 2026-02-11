using Common.Enum;
using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class ProductUpdateDto
    {
        public Guid PublicId { get; set; }
        public string? Name { get; set; }
        public string? Info { get; set; }
        public List<CategoryEnum>? Categories { get; set; }
        public float? Price { get; set; }
    }
}
