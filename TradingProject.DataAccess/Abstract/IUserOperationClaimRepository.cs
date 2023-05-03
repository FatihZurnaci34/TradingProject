using Core.DataAccess.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingProject.DataAccess.Abstract
{
    public interface IUserOperationClaimRepository:IAsyncRepository<UserOperationClaim>,IRepository<UserOperationClaim>
    {
    }
}
