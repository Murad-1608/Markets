﻿using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IBranchesRepository
    {
        int Insert(BranchEntity entity);
        int Update(BranchEntity entity);
        int Delete(int Id);
        List<BranchesModel> GetBranches();
    }
}
