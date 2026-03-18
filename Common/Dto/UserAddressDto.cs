namespace Common.Dto
{
    public class UserAddressDto
    {
        public Guid PublicId { get; set; }
        public Guid UserPublicId { get; set; }
        public string Street { get; set; } = "";
        public int HouseNumber { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public int PostalCode { get; set; }
    }
}