using Core.DataAccess.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.DataAccess.Abstract;

namespace TradingProject.Business.SecurityServices
{
    public class AuthsManager : IAuthsService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public AuthsManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(
                    u => u.UserId == user.Id,
                    include: u => u.Include(u => u.OperationClaim)
                );
            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<UserOperationClaim> CreateAndAddUserClaim(User user)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == "User");
            UserOperationClaim userOperationClaim = new() { UserId = user.Id, OperationClaimId = operationClaim.Id };
            return await _userOperationClaimRepository.AddAsync(userOperationClaim);
        }

        public async Task<RefreshToken> CreateRefreshToken(User user)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user);
            return await Task.FromResult(refreshToken);
        }
    }
}
