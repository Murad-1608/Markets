using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public class BranchesModel:BaseModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Location { get; set; }
        public int Profit { get; set; }
        public string PhoneNumber { get; set; }
        public int Balance { get; set; }

        public override object Clone()
        {
            return new BranchesModel
            {
                Id = Id,
                Location = Location,
                Profit = Profit,
                PhoneNumber = PhoneNumber,               
                Balance = Balance              
            };

        }
    }
}
