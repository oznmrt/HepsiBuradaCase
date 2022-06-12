using HP.BACKEND.ENTITIES.Abstract;
using HP.BACKEND.ENTITIES.Concrete.Response;
using HP.BACKEND.REPOSITORY.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.BUSINESS.Abstract
{
    public abstract class BaseService<TEntity, TRepository> where TEntity : class, IEntity, new() where TRepository : IRepository
    {
        protected readonly TRepository _baseServiceRepository;

        protected BaseService(TRepository baseServiceRepository)
        {
            _baseServiceRepository = baseServiceRepository;
        }

        public abstract Task<int> Insert(TEntity entity);
        public abstract Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] relations);
        public abstract Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params string[] relations);
        public abstract Task<int> Update(TEntity entity);
        public abstract Task Delete(TEntity entity);
    }
}
