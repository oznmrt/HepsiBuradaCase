using HP.BACKEND.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Abstract
{
    public interface IColorRepository: IEntityRepository<Color>, IRepository
    {
    }
}
