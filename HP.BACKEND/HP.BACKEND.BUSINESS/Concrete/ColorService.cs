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
    public class ColorService : BaseService<Color, IColorRepository>
    {
        public ColorService(IColorRepository baseServiceRepository) : base(baseServiceRepository)
        {
        }

        public async override Task<Color> Get(Expression<Func<Color, bool>> filter = null, params string[] relations)
        {
            return await _baseServiceRepository.Get(filter, relations);
        }

        public async override Task<IEnumerable<Color>> GetAll(Expression<Func<Color, bool>> filter = null, params string[] relations)
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

        public async override Task<int> Insert(Color entity)
        {
            await _baseServiceRepository.Insert(entity);
            return entity.Id;
        }

        public async override Task<int> Update(Color entity)
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

        public override Task Delete(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
