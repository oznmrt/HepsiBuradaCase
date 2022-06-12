using HP.BACKEND.ENTITIES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.ENTITIES.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
    }
}
