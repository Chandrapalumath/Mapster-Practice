namespace Mapster_Practice.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } // Flattened from First + Last
        public string Email { get; set; }
        public string FullAddress { get; set; } // Flattened from Address object
    }
}
