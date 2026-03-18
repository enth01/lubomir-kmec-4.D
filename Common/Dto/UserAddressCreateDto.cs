using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class UserAddressCreateDto
    {
        [Required]
        public Guid UserPublicId { get; set; }
        [Required]
        public required string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string Country { get; set; }
        [Required]
        public int PostalCode { get; set; }
    }
}