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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

   
        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.CadastrarConsulta(consulta);

                return Ok(consulta);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return Ok("Consulta deletada!");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAction()
        {
            try
            {
                return Ok(_consultaRepository.ListarConsultasAdm());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("consultaspaciente/{id}")]
        public IActionResult GetPaciente(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.ListarConsultasPaciente(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("consultasmedico/{id}")]
        public IActionResult GetMedico(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.ListarConsultasMedico(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
