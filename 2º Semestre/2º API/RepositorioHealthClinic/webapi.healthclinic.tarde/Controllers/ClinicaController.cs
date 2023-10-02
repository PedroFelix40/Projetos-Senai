using Microsoft.AspNetCore.Authorization;
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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

                if (clinicaBuscada == null)
                {
                    return NotFound("Clinica não encontrda!");
                }

                _clinicaRepository.Atualizar(id, clinica);

                return Ok("Clinica atualizada!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return Ok(clinica);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
