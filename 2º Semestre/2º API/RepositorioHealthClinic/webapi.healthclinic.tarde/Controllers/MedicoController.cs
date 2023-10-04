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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// EndPoint Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

                if (medicoBuscado == null)
                {
                    return NotFound("Médico não encontrado!");
                }

                _medicoRepository.Atualizar(id, medico);

                return Ok("Médico atualizado!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Cdastrar
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return Ok(medico);
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
                Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

                if (medicoBuscado == null)
                {
                    return NotFound("Médico não encontrado!");
                }

                _medicoRepository.Deletar(id);

                return Ok("Médico deletado!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
