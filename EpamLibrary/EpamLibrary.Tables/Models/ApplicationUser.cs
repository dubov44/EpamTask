using Microsoft.AspNet.Identity.EntityFramework;

namespace EpamLibrary.Tables.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}