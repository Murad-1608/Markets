using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public abstract class BaseModel:ICloneable
    {
        public int Id { get; set; }
        public int No { get; set; }

        public abstract object Clone();
        
    }
}
