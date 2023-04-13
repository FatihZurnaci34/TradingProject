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
    public class ProductRepository : EfRepositoryBase<Product, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
