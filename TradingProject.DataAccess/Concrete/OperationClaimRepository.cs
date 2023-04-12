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
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
