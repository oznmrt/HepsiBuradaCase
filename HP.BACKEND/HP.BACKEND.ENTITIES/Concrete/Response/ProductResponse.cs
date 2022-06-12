using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.ENTITIES.Concrete.Response
{
    public class ProductResponse
    {
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public int MaxPageCount { get; set; } = 1;
    }
}
