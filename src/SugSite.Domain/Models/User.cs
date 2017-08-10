using Microsoft.AspNetCore.Identity;
using SugSite.Domain.Abstract;

namespace SugSite.Domain.Models
{
    public class User : IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public bool IsDeleted { get; set; }
        public bool AllowUserGroupEmails { get; set; }
        public bool AllowGenericEmails { get; set; }
    }
}