using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class CommentEntity : BaseEntity 
    {
        public string Name { get; set; }
        public string Info { get; set; }
        int UserId { get; set; }
        UserEntity User { get; set; }
        int ProductId { get; set; }
        ProductEntity Product { get; set; }
        string Text { get; set; }
    }
}
