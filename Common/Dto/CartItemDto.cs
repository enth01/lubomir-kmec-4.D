using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class CartItemDto
    {
        public Guid productPublicId { get; set; }
        public Guid userPublicId { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public int quantity { get; set; }
    }
}
