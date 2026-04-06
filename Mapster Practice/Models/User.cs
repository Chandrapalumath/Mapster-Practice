namespace Mapster_Practice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Should NOT be in DTO
        public Address HomeAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
