using SugSite.Domain.Abstract;
using SugSite.Domain.Models;

namespace SugSite.Domain.Concrete
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}