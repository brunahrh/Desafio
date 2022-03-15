using DesafioCursos.Enum;
using DesafioCursos.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ConfiguracoesJWT ConfiguracoesJWT;
        public AutenticacaoController(IOptions<ConfiguracoesJWT> options)
        {
            ConfiguracoesJWT = options.Value;
        }

        [HttpGet]
        public IActionResult ObterToken(UsuarioEnum usuario)
        {
            var token = GerarToken(usuario);

            var retorno = new
            {
                Token = token
            };
            return Ok(retorno);
        }

        private string GerarToken(UsuarioEnum usuario)
        {
            IList<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, usuario.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, ClaimTypes.Role);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfiguracoesJWT.Segredo)), SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "DesafioCursos",
                Subject = new ClaimsIdentity(claims),
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
