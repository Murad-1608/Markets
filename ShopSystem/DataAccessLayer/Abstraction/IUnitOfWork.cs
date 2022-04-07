﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IUnitOfWork
    {
        IUserRepository EmployeeRepository { get; }
        IBranchesRepository BranchesRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
