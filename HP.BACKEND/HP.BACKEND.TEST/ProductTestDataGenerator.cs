using HP.BACKEND.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.TEST
{
    public class ProductTestDataGenerator
    {
        public static IEnumerable<Product[]> GetProductFromDataGenerator()
        {
            yield return new Product[]
            {
                new Product {Id = 1, Name="Product 1",Price=54,DiscountRatio=96, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=1},
                new Product {Id = 2, Name="Product 2",Price=61,DiscountRatio=75, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=1,BrandId=2},
                new Product {Id = 3, Name="Product 3",Price=29,DiscountRatio=64, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=2},
                new Product {Id = 4, Name="Product 4",Price=12,DiscountRatio=65, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=2},
                new Product {Id = 5, Name="Product 5",Price=83,DiscountRatio=47, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=1},
            };
        }

        public static IEnumerable<Product> GetProductListFromDataGenerator()
        {
            return new List<Product>
            {
                new Product {Id = 1, Name="Product 1",Price=54,DiscountRatio=96, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=1},
                new Product {Id = 2, Name="Product 2",Price=61,DiscountRatio=75, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=1,BrandId=2},
                new Product {Id = 3, Name="Product 3",Price=29,DiscountRatio=64, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=2},
                new Product {Id = 4, Name="Product 4",Price=12,DiscountRatio=65, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=2},
                new Product {Id = 5, Name="Product 5",Price=83,DiscountRatio=47, ImagePath="https=//productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg",ColorId=2,BrandId=1},
            };
        }
    }
}
