using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Core.DataAccess.Repositories;
using TradingProject.Core.Entities;

namespace TradingProject.DataAccess.Abstract
{
    public interface IOperationClaimRepository:IAsyncRepository<OperationClaim>,IRepository<OperationClaim>
    {
    }
}
