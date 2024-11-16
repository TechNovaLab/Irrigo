namespace TechNovaLab.Irrigo.Domain.Entities.Users
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string PasswordHash { get; set; } = default!;
        public Role Rol { get; set; }
    }
}
