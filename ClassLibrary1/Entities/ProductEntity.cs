using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class ProductEntity : BaseEntity
    {

        public string Name { get; set; }

        public string Info { get; set; }

        public List<CategoryEnum> Categories { get; set; } = [];

        public float Price { get; set; }
    }
}
