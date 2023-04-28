using Microsoft.AspNetCore.Identity;

namespace DsrProject.Context.Entities
{

    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public UserStatus Status { get; set; }
        public ICollection<ThoughtUser>? ThoughtUsers { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}