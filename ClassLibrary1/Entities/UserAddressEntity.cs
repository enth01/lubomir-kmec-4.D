namespace ClassLibrary1.Entities
{
    public class UserAddressEntity : BaseEntity
    {
        public int UserId { get; set; }
        public required UserEntity User { get; set; }
        public required string Street { get; set; }
        public int HouseNumber { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public int PostalCode { get; set; }
    }
}