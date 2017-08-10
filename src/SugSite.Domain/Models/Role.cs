using Microsoft.AspNetCore.Identity;
using SugSite.Domain.Abstract;

namespace SugSite.Domain.Models
{
    public class Role : IdentityRole<int>, IEntity
    {
    }
}