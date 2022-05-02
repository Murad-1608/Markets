using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string BranchName { get; set; }
        public BranchesModel Branch { get; set; }
        public int Id { get; set; }
        public int BranchID { get; set; }      
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Comment { get; set; }
    }
}
