namespace WebApplication1.Models
{
    public class User
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required int Tel { get; set; }
        public required string Address { get; set; }
        //public required List<string> ChorobyInput { get; set; } = new List<string>();
        public required string ChorobyInput { get; set; }
        //public required List<string> ChorobyList { get; set; } = ChorobyInput.Split(',').ToList();
    }
}
