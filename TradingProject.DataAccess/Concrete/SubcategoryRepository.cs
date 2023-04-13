using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.DataAccess.Abstract;
using TradingProject.Entities.Concrete;

namespace TradingProject.DataAccess.Concrete
{
    public class SubcategoryRepository : EfRepositoryBase<Subcategory, BaseDbContext>, ISubcategoryRepository
    {
        public SubcategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
