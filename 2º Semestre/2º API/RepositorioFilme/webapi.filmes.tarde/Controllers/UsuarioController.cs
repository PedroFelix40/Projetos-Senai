using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de api
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado. Email ou senha inválidos!");
                }

                // caso encontre o usuario buscado, prossegue para a criação do token

                //1 - definir as informações(Claims) basicas que serão fornecidas no token (payload)
                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                //2 - definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-atenticacao-webapi-dev"));

                //3 - definir as credencias do token (Header)
                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                //4 - gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.filmes.tarde",

                    //destinario
                    audience: "webapi.filmes.tarde",

                    //dados definidos nas claims(Payload)
                    claims : claims,

                    //tempo de expiração 
                    expires : DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials : creds
                );

                //5 - retornar o token 
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message); 
            }
        }
    }
}
