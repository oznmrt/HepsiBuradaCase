using HP.BACKEND.ENTITIES.Concrete.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.TEST
{
    public class ProductAPITestDataGenerator
    {
        public static IEnumerable<object[]> GetProductAPIFromDataGenerator()
        {
            yield return new GetAllProductsRequest[]
            {
                new GetAllProductsRequest { BrandId = 1, ColorId = 2},
                new GetAllProductsRequest { SearchText = "Test" },
                new GetAllProductsRequest { Page = 2, SortByDateDESC = true },
                new GetAllProductsRequest { Page = 3 },
                new GetAllProductsRequest { SortByPriceASC = true },
            };
        }
        public static IEnumerable<object[]> GetProductAPIFromDataGeneratorSingle()
        {
            yield return new GetAllProductsRequest[]
            {
                new GetAllProductsRequest { BrandId = 1, ColorId = 2}
            };
        }
    }
}
