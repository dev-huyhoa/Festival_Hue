using Festival_Hue.Interface;
using Festival_Hue.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Festival_Hue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        public IAuthentication _authentication;
        public IConfiguration _configuration;
        public TokenController(IAuthentication authentication, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration = configuration;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(ViewLogin viewLogin)
        {
            try
            {
                if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.UserEmail) && !string.IsNullOrEmpty(viewLogin.UserPassword))
                {
                    var user = await _authentication.Login(viewLogin);

                    if (user != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("Email", user.EmailUser),
                             new Claim(ClaimTypes.Role , user.RoleId.ToString())
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                            claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                        ViewToken viewToken = new ViewToken()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User = user
                        };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }   
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
