using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface ICompaniesRepository
    {
        int Insert(CompaniesEntity entity);
        int Update(CompaniesEntity entity);
        int Delete(int Id);
        List<CompaniesEntity> GetCompanies();
    }
}
