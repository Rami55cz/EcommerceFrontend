namespace EcommerceFrontend.Models{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? GitHubId { get; set; }
        public string? Username { get; set; }

        // Editable by the user
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // Role: "customer", "administrator", or "vendor"
        public string? Role { get; set; } = "customer";
    }
}