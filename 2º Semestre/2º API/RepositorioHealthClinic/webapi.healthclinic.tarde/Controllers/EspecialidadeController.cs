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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// EndPoint Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                Especialidade especialidadeBuscada = _especialidadeRepository.BuscarPorId(id);

                if (especialidadeBuscada == null)
                {
                    return NotFound("Especialidade não encontrado!");
                }

                _especialidadeRepository.Atualizar(id, especialidade);

                return Ok("Especialidade atualizada!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Cadastrar
        /// </summary>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return Ok(especialidade);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
