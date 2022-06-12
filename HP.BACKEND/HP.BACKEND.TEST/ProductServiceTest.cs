using HP.BACKEND.BUSINESS.Concrete;
using HP.BACKEND.ENTITIES.Concrete;
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
    public class ProductServiceTest
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        public ProductServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(ProductTestDataGenerator.GetProductFromDataGenerator), MemberType = typeof(ProductTestDataGenerator))]
        public async void Insert_Product_ReturnValue(Product product1, Product product2, Product product3, Product product4, Product product5)
        {
            _productRepositoryMock.Setup(x => x.Insert(product1));
            _productRepositoryMock.Setup(x => x.Insert(product2));
            _productRepositoryMock.Setup(x => x.Insert(product3));
            _productRepositoryMock.Setup(x => x.Insert(product4));
            _productRepositoryMock.Setup(x => x.Insert(product5));

            var actual1 = await _productService.Insert(product1);
            var actual2 = await _productService.Insert(product2);
            var actual3 = await _productService.Insert(product3);
            var actual4 = await _productService.Insert(product4);
            var actual5 = await _productService.Insert(product5);

            Assert.Equal(1, actual1);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
        }

        [Theory]
        [MemberData(nameof(ProductTestDataGenerator.GetProductFromDataGenerator), MemberType = typeof(ProductTestDataGenerator))]
        public async void Update_Product_ReturnValue(Product product1, Product product2, Product product3, Product product4, Product product5)
        {
            _productRepositoryMock.Setup(x => x.Update(product1));
            _productRepositoryMock.Setup(x => x.Update(product2));
            _productRepositoryMock.Setup(x => x.Update(product3));
            _productRepositoryMock.Setup(x => x.Update(product4));
            _productRepositoryMock.Setup(x => x.Update(product5));

            var actual1 = await _productService.Update(product1);
            var actual2 = await _productService.Update(product2);
            var actual3 = await _productService.Update(product3);
            var actual4 = await _productService.Update(product4);
            var actual5 = await _productService.Update(product5);

            Assert.Equal(1, actual1);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
        }
    }
}
