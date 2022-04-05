using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Entities
{
    internal class ProductEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Comment { get; set; }
    }
}
