using HP.BACKEND.ENTITIES.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.ENTITIES.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRatio { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public string ImagePath { get; set; }

        [ForeignKey(nameof(HP.BACKEND.ENTITIES.Concrete.Color))]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        [ForeignKey(nameof(HP.BACKEND.ENTITIES.Concrete.Brand))]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
