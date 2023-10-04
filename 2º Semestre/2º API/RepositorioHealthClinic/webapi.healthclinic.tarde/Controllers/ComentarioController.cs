using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// EndPoint Cadastrar
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);

                return Ok(comentario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.BuscarPorId(id);

                if (comentarioBuscado == null)
                {
                    return NotFound("Comentário não encontrado!!");
                }

                _comentarioRepository.Deletar(id);

                return Ok("Comentário deletado!!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
