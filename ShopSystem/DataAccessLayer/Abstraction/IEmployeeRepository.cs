﻿using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IEmployeeRepository
    {
        List<EmployeeEntity> Employees();
        int Delete(int Id);
        int Update(EmployeeEntity model);
        int Insert(EmployeeEntity model);
        int Get(string Email);
    }
}
