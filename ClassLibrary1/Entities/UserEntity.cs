using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class UserEntity : BaseEntity
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public RoleEnum Role { get; set; } = RoleEnum.user;

        public List<CartItemEntity> Cart { get; set; } = [];
    }
}
