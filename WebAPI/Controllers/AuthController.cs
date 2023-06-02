using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingProject.Business.Abstract;
using TradingProject.Business.Concrete;
using TradingProject.Entities.Dtos.Auths;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("RegisterForCustomer")]
        public async Task<IActionResult> RegisterForCustomer([FromBody] CustomerForRegisterDto customerForRegisterDto)
        {
            
            RegisteredDto result = await _authService.CustomerForRegister(customerForRegisterDto);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }

        [HttpPost("RegisterForSupplier")]
        public async Task<IActionResult> RegisterForSupplier([FromBody] SupplierForRegisterDto supplierForRegisterDto)
        {

            RegisteredDto result = await _authService.SupplierForRegister(supplierForRegisterDto);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            LoginedDto result = await _authService.CustomerForLogin(userForLoginDto);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
