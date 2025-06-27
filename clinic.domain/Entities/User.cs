using Microsoft.AspNetCore.Identity;

namespace clinic.domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
