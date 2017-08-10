using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SugSite.Domain.Abstract;

namespace SugSite.Domain.Concrete
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        public ApplicationDbContext DbContext { get; private set; }
        private DbSet<T> DbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public IQueryable<T> All
        {
            get
            {
                return DbSet.AsQueryable();
            }
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public async Task<T> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void InsertOrUpdate(T entity)
        {
            if (entity.Id == default(int))
            {
                DbSet.Add(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
        }

        public async void Delete(int id)
        {
            T dbSet = await FindAsync(id);
            DbSet.Remove(dbSet);
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}