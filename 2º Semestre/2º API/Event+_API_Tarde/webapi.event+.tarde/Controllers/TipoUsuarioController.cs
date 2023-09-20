using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// EndPoint para atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                
                return Ok("Tipo usuario atualizado com sucesso!");

            }
            catch (Exception e)
            {

                return BadRequest("Tipo de usuario não encontrado e/ou informações inválidas!");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));

            }
            catch (Exception e)
            {

                return BadRequest("Tipo de usuario não encontrado!");
            }
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest("Dados inválidos para criação de um novo tipo de usuario");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return Ok("Tipo de usuario deletado");
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
