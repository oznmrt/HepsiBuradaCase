using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        Task<int> Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] relations);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params string[] relations);
    }
}
