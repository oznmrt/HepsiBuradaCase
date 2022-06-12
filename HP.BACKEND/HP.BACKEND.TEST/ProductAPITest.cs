using HP.BACKEND.API.Controllers;
using HP.BACKEND.BUSINESS.Concrete;
using HP.BACKEND.COMMON.Constants;
using HP.BACKEND.ENTITIES.Concrete;
using HP.BACKEND.ENTITIES.Concrete.Request;
using HP.BACKEND.ENTITIES.Concrete.Response;
using HP.BACKEND.REPOSITORY.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HP.BACKEND.TEST
{
    public class ProductAPITest
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductController _productController;
        public ProductAPITest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
            _productController = new ProductController(_productService);
        }

        [Theory]
        [MemberData(nameof(ProductAPITestDataGenerator.GetProductAPIFromDataGenerator), MemberType = typeof(ProductAPITestDataGenerator))]
        public async void Get_Products_API_ReturnValue(GetAllProductsRequest request1, GetAllProductsRequest request2, GetAllProductsRequest request3, GetAllProductsRequest request4, GetAllProductsRequest request5)
        {
            var responseData = ProductTestDataGenerator.GetProductListFromDataGenerator().ToList();
            _productRepositoryMock.Setup(x => x.GetAll(null, new string[] { Constants.Relations.Brand, Constants.Relations.Color })).ReturnsAsync(responseData);

            var actual1 = await _productController.GetProducts(request1);
            var actual2 = await _productController.GetProducts(request2);
            var actual3 = await _productController.GetProducts(request3);
            var actual4 = await _productController.GetProducts(request4);
            var actual5 = await _productController.GetProducts(request5);

            Assert.IsType<ProductResponse>(actual1);
            Assert.IsType<ProductResponse>(actual2);
            Assert.IsType<ProductResponse>(actual3);
            Assert.IsType<ProductResponse>(actual4);
            Assert.IsType<ProductResponse>(actual5);
        }

        [Theory]
        [MemberData(nameof(ProductAPITestDataGenerator.GetProductAPIFromDataGeneratorSingle), MemberType = typeof(ProductAPITestDataGenerator))]
        public async void Get_Products_API_ReturnValue_PageCount(GetAllProductsRequest request1)
        {
            var responseData = ProductTestDataGenerator.GetProductListFromDataGenerator().ToList();
            responseData.AddRange(responseData);
            responseData.AddRange(responseData);
            responseData.AddRange(responseData);
            _productRepositoryMock.Setup(x => x.GetAll(null, new string[] { Constants.Relations.Brand, Constants.Relations.Color })).ReturnsAsync(responseData.ToList());

            var actual1 = await _productController.GetProducts(request1);

            Assert.Equal(2, actual1.MaxPageCount);
        }
    }
}
