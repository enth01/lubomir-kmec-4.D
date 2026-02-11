using Common.Enum;
using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public required string Info { get; set; }
        public List<CategoryEnum> Categories { get; set; } = new();
        public float Price { get; set; }
    }
}
