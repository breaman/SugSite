using SugSite.Domain.Abstract;

namespace SugSite.Domain.Models
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}