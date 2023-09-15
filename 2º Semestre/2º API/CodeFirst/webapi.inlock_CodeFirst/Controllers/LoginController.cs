using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interface;
using webapi.inlock_CodeFirst.Repositories;
using webapi.inlock_CodeFirst.ViewModels;

namespace webapi.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email,usuario.Senha);

                if(usuarioBuscado == null)
                {
                    return StatusCode(401,"Email e/ou senha inválidos!");
                }
                //fazer a lógica do token
                //configurar o jwt

                //1 - definir as informações(Claims) basicas que serão fornecidas no token (payload)
                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                   // new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo),
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                //2 - definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-atenticacao-webapi-dev"));

                //3 - definir as credencias do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.inlock.tarde",

                    //destinario
                    audience: "webapi.inlock.tarde",

                    //dados definidos nas claims(Payload)
                    claims: claims,

                    //tempo de expiração 
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //5 - retornar o token 
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
