using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    internal class UserModel:BaseModel
    {  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; } = "User";

        public override object Clone()
        {
            return new UserModel
            { 
                Id=Id,
                Name=Name,
                Surname=Surname,
                FatherName=FatherName,
                Email=Email,
                Password=Password,
                PhoneNumber=PhoneNumber,
                Position=Position
            };

        }
    }
}
