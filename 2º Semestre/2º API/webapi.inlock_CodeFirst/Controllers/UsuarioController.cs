using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interface;
using webapi.inlock_CodeFirst.Repositories;

namespace webapi.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Falta implementar o endpoint
        [HttpGet]
        public IActionResult GetByEmailAndPassword()
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
