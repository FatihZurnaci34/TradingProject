using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Business.Abstract;
using TradingProject.Business.Rules;
using TradingProject.Business.SecurityServices;
using TradingProject.DataAccess.Abstract;
using TradingProject.DataAccess.Concrete;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Auths;

namespace TradingProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private readonly IAuthsService _authService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;

        public AuthManager(IAuthsService authService, ICustomerRepository customerRepository, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
        {
            _authService = authService;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
        }

        public AuthManager()
        {
        }

        public async Task<RegisteredDto> CustomerForRegister(CustomerForRegisterDto customerForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(customerForRegisterDto.Password, out passwordHash, out passwordSalt);
            Customer newCustomer = new()
            {
                Email = customerForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = customerForRegisterDto.FirstName,
                LastName = customerForRegisterDto.LastName,
                Gender = customerForRegisterDto.Gender,
                Status = true
            };
            Customer createdUser = await _customerRepository.AddAsync(newCustomer);
            await _authService.CreateAndAddUserClaim(createdUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredDto registeredDto = new()
            {
                RefreshToken = addedRefreshToken,
                AccessToken = createdAccessToken,
            };
            return registeredDto;
        }

        public async Task<LoginedDto> CustomerForLogin(UserForLoginDto userForLoginDto)
        {
            await _authBusinessRules.CheckIfEmailIsCorrect(userForLoginDto.Email);
            var user = await _userRepository.GetAsync(x => x.Email == userForLoginDto.Email);
            _authBusinessRules.CheckIfPasswordIsCorrect(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            var createdAccessToken = await _authService.CreateAccessToken(user);
            var createdRefreshToken = await _authService.CreateRefreshToken(user);
            var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new LoginedDto()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };
        }
    }
}
