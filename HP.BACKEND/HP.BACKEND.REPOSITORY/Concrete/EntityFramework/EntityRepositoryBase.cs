using HP.BACKEND.ENTITIES.Abstract;
using HP.BACKEND.REPOSITORY.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Concrete.EntityFramework
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params string[] relations)
        {
            using (TContext context = new TContext())
            {
                var ctx = context.Set<TEntity>().AsTracking().AsQueryable();
                foreach (var item in relations)
                {
                    ctx = ctx.Include(item);
                }

                return await ctx.SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] relations)
        {
            using (TContext context = new TContext())
            {
                if (relations.Length > 0)
                {
                    var ctx = context.Set<TEntity>().AsQueryable();
                    foreach (var item in relations)
                    {
                        ctx = ctx.Include(item);
                    }
                    return filter == null ? await ctx.ToListAsync() : await ctx.Where(filter).ToListAsync();
                }

                return filter == null ? await context.Set<TEntity>().ToListAsync() :
                                        await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<int> Insert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
