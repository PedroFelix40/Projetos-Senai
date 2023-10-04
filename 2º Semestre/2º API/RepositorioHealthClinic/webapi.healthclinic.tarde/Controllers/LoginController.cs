using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;
using webapi.healthclinic.tarde.ViewMoldels;

namespace webapi.healthclinic.tarde.Controllers
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

        /// <summary>
        /// EndPoint Logar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email e/ou senha inválidos!");
                }
                //fazer a lógica do token
                //configurar o jwt

                //1 - definir as informações(Claims) basicas que serão fornecidas no token (payload)
                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!),
                };

                //2 - definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-tarde-chave-atenticacao-webapi-dev"));

                //3 - definir as credencias do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.health.tarde",

                    //destinario
                    audience: "webapi.health.tarde",

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
