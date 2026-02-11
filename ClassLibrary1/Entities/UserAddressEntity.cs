using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class UserAdderssEntity : BaseEntity 
    {
        int UserId { get; set; }
        UserEntity User { get; set; }
        string Street { get; set; }
        int HouseNumber { get; set; }
        string Country { get; set; }
        string City { get; set; }
        int PostalCode { get; set; }
    }
}
