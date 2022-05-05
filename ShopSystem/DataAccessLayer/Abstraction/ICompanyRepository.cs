using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface ICompanyRepository
    {
        int Insert(CompanyEntity entity);
        int Update(CompanyEntity entity);
        int Delete(int Id);
        List<CompanyEntity> GetCompanies();
    }
}
