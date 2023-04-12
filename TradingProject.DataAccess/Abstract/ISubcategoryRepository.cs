using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Core.DataAccess.Repositories;
using TradingProject.Entities.Concrete;

namespace TradingProject.DataAccess.Abstract
{
    public interface ISubcategoryRepository:IAsyncRepository<Subcategory>,IRepository<Subcategory>
    {
    }
}
