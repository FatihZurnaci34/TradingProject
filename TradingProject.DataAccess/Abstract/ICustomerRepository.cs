using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;

namespace TradingProject.DataAccess.Abstract
{
    public interface ICustomerRepository : IAsyncRepository<Customer>, IRepository<Customer>
    {
    }
}
