using HP.BACKEND.BUSINESS.Abstract;
using HP.BACKEND.ENTITIES.Concrete;
using HP.BACKEND.ENTITIES.Concrete.Response;
using HP.BACKEND.REPOSITORY.Abstract;
using HP.BACKEND.REPOSITORY.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.BUSINESS.Concrete
{
    public class ProductService : BaseService<Product, IProductRepository>
    {
        public ProductService(IProductRepository baseServiceRepository) : base(baseServiceRepository)
        {
        }

        public async override Task<Product> Get(Expression<Func<Product, bool>> filter = null, params string[] relations)
        {
            return await _baseServiceRepository.Get(filter, relations);
        }

        public async override Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null, params string[] relations)
        {
            try
            {
               return await _baseServiceRepository.GetAll(filter, relations);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async override Task<int> Insert(Product entity)
        {
            await _baseServiceRepository.Insert(entity);
            return entity.Id;
        }

        public async override Task<int> Update(Product entity)
        {
            try
            {
                await _baseServiceRepository.Update(entity);
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override Task Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
