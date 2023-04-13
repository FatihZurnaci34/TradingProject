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
    public class SupplierRepository : EfRepositoryBase<Supplier, BaseDbContext>, ISupplierRepository
    {
        public SupplierRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
