namespace Ecooperation_backend.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ushort Age { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}
