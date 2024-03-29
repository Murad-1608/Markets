﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public class ProductModel : BaseModel
    {
        public BranchModel Branch { get; set; }
        public string BranchName { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Comment { get; set; }


        public override object Clone()
        {
            return new ProductModel
            {
                Id = Id,
                Name = Name,
                Brand = Brand,
                Price = Price,
                Count = Count,
                Type = Type,
                Color = Color,
                Comment = Comment,
                Branch = (BranchModel)Branch?.Clone()
            };

        }


    }
}
