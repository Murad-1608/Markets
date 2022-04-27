using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public abstract class BaseMapper<TModel,TEntity> where TModel:BaseModel where TEntity : BaseEntity
    {
        public abstract TModel Map(TEntity entity);
        public abstract TEntity Map(TModel model);

    }
}
