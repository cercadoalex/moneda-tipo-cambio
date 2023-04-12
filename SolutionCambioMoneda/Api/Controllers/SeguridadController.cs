using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private AppSettings _appSettings;

        public SeguridadController(IConfiguration config, IOptions<AppSettings> appSettings)
        {
            this.configuration = config;
            _appSettings = appSettings.Value;
        }
        [HttpGet("GetToken")]
        public ActionResult<string> GetToken()
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var KeyValue = Encoding.ASCII.GetBytes(_appSettings.KeyApi);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity
              (new Claim[]
              {
                  new Claim(ClaimTypes.NameIdentifier, "1"),
                  new Claim(ClaimTypes.Name, "TipoCambio"),
                  new Claim(ClaimTypes.Role, "Administrador")
              }),
                Expires = DateTime.UtcNow.AddSeconds(double.Parse(_appSettings.ExpirationInMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyValue), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }


    }
}
