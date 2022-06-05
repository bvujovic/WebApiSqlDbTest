using System.ComponentModel.DataAnnotations;

namespace ClassLib
{
    /// <summary>
    /// Korisnik aplikacije.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public bool IsActive { get; set; } = true;

        public List<Target>? OwnedTargets { get; set; } = null;
    }
}