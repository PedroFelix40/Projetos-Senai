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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        /// <summary>
        /// EndPoint Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comentarioEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ComentarioEvento comentarioEvento)
        {
            ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorId(id);

            if (comentarioBuscado == null)
            {
                return NotFound("Comentario não encontrado!");
            }

            _comentarioEventoRepository.Atualizar(id, comentarioEvento);

            return Ok(comentarioBuscado);
        }

        /// <summary>
        /// EndPoint BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorId(id);

                if (comentarioBuscado == null)
                {
                    return NotFound("Comentario não encontrado!");
                }

                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Cadastrar
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentario)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentario);

                return Ok("Comentario cadastrado com sucesso!");
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
            ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorId(id);

            if (comentarioBuscado == null)
            {
                return NotFound("Comentario não encontrado!");
            }

            _comentarioEventoRepository.Deletar(id);

            return Ok("Comentario deletado");
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
                return Ok(_comentarioEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
