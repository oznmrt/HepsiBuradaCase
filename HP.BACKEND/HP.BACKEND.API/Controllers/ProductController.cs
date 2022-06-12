using HP.BACKEND.BUSINESS.Concrete;
using HP.BACKEND.COMMON.Constants;
using HP.BACKEND.ENTITIES.Concrete;
using HP.BACKEND.ENTITIES.Concrete.Request;
using HP.BACKEND.ENTITIES.Concrete.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HP.BACKEND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("testme")]
        public async Task<string> testme()
        {
            var data = await _productService.GetAll(null, Constants.Relations.Brand, Constants.Relations.Color);
            return "i am ok";
        }

        [HttpPost]
        [Route("getproducts")]
        public async Task<ProductResponse> GetProducts([FromBody] GetAllProductsRequest request)
        {
            var productData = (await _productService.GetAll(relations: new string[] { Constants.Relations.Brand, Constants.Relations.Color }));

            if (request.ColorId.HasValue && request.BrandId.HasValue)
                productData = productData.Where(p => p.ColorId == request.ColorId.Value && p.BrandId == request.BrandId.Value);
            else if (request.ColorId.HasValue)
                productData = productData.Where(p => p.ColorId == request.ColorId.Value);
            else if (request.BrandId.HasValue)
                productData = productData.Where(p => p.BrandId == request.BrandId.Value);

            if(request.SortByDateDESC)
                productData = productData.ToList().OrderByDescending(p => p.InsertDate);
            if(request.SortByDateASC)
                productData = productData.ToList().OrderBy(p => p.InsertDate);
            if (request.SortByPriceDESC)
                productData = productData.ToList().OrderByDescending(p => p.Price);
            if (request.SortByPriceASC)
                productData = productData.ToList().OrderBy(p => p.Price);

            if(!string.IsNullOrEmpty(request.SearchText))
                productData = productData.Where(p => p.Name.ToLower().Contains(request.SearchText.ToLower()));

            var skipCount = request.Page.HasValue && request.Page.Value > 1 ? (request.Page.Value - 1) * Constants.ProductPageCount : 0;

            return new ProductResponse
            {
                Products = productData.Skip(skipCount).Take(Constants.ProductPageCount).ToList(),
                Brands = productData.Select(x => x.Brand).ToList(),
                Colors = productData.Select(x => x.Color).ToList(),
                MaxPageCount = (int)Math.Ceiling((double)productData.Count() / Constants.ProductPageCount)
            };
        }
    }
}
