using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.ENTITIES.Concrete.Request
{
    public class GetAllProductsRequest
    {
        public int? Page { get; set; }
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public bool SortByPriceDESC { get; set; } = false;
        public bool SortByPriceASC { get; set; } = false;
        public bool SortByDateDESC { get; set; } = false;
        public bool SortByDateASC { get; set; } = false;
        public string SearchText { get; set; } = string.Empty;
    }
}
