using HP.BACKEND.BUSINESS.Abstract;
using HP.BACKEND.ENTITIES.Concrete;
using HP.BACKEND.ENTITIES.Concrete.Response;
using HP.BACKEND.REPOSITORY.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.BUSINESS.Concrete
{
    public class BrandService : BaseService<Brand, IBrandRepository>
    {
        public BrandService(IBrandRepository baseServiceRepository) : base(baseServiceRepository)
        {
        }

        public async override Task<Brand> Get(Expression<Func<Brand, bool>> filter = null, params string[] relations)
        {
            return await _baseServiceRepository.Get(filter, relations);
        }

        public async override Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null, params string[] relations)
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

        public async override Task<int> Insert(Brand entity)
        {
            await _baseServiceRepository.Insert(entity);
            return entity.Id;
        }

        public async override Task<int> Update(Brand entity)
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

        public override Task Delete(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
