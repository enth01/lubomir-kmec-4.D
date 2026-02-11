using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class OrderEntity : BaseEntity 
    {
        List<CartItemEntity> Items { get; set; }
        float TotalPrice { get; set; }
        int AddressId { get; set; }
        UserAdderssEntity Address { get; set; }
        StatusEnum Status { get; set; }
    }
}
