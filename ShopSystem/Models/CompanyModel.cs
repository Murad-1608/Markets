using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public class CompanyModel : BaseModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }

        public override object Clone()
        {
            return new CompanyModel
            {
                Id = Id,
                Name = Name
            };
        }
    }
}