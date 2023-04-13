﻿using Core.DataAccess.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingProject.DataAccess.Abstract
{
    public interface IRefreshTokenRepository:IAsyncRepository<RefreshToken>,IRepository<RefreshToken>
    {
    }
}
