﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Entities
{
    public  class BranchEntity
    {
        public int Id { get; set; }
        public string Location  { get; set; }
        public int Profit  { get; set; }
        public string PhoneNumber  { get; set; }       
        public int Balance { get; set; }
    }
}
