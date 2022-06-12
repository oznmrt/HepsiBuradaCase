using HP.BACKEND.ENTITIES.Concrete;
using HP.BACKEND.REPOSITORY.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Concrete.EntityFramework
{
    public class ProductRepository: EntityRepositoryBase<Product, HPCaseDBContext>, IProductRepository
    {
    }
}
