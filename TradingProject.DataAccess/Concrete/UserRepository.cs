using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Core.DataAccess.Repositories;
using TradingProject.Core.Entities;
using TradingProject.DataAccess.Abstract;

namespace TradingProject.DataAccess.Concrete
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
