
namespace Domain.Users
{
    public class User
    {
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PasswordHash { get; set; }
    public Role Role { get; set; }
    }

    public enum Role
    {
        Owner = 0,
        Admin = 1,
        User = 3,
    }
}
