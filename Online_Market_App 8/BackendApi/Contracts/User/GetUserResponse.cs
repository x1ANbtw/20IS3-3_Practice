namespace BackendApi.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Addres { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
