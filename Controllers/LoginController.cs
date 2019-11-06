using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API_TechCycle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        // Chamamos nosso contexto do banco
        TECHCYCLEContext context = new TECHCYCLEContext();

        // Definimos uma variável para percorrer nossos métodos com as configurações obtidas no appsettings.json
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            IActionResult response = Unauthorized();
            
            var usuario = autenticarUsuario(login);

            if(usuario != null)
            {
                var tokenString = gerarJsonWebToken(usuario);
                response = Ok( new { token = tokenString});
            }

            return response;
        }

        private Usuario autenticarUsuario(Usuario login)
        {
            var usuario = context.Usuario.FirstOrDefault(us => us.Email == login.Email && us.Senha == login.Senha);

            if(usuario != null)
                return login;

            return usuario;
        }

        private string gerarJsonWebToken(Usuario infoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.NameId, infoUsuario.Nome),
                new Claim(JwtRegisteredClaimNames.Email, infoUsuario.Email),
                new Claim(ClaimTypes.Role, infoUsuario.TipoUsuario),
                new Claim("Roles", infoUsuario.TipoUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}