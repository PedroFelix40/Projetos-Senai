﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(id);

                if (pacienteBuscado == null)
                {
                    return NotFound("Paciente não encontrado!");
                }

                _pacienteRepository.Atualizar(id, paciente);

                return Ok("Paciente atualizado!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return Ok(paciente);
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
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(id);

                if (pacienteBuscado == null)
                {
                    return NotFound("Paciente não encontrado!");
                }

                _pacienteRepository.Deletar(id);

                return Ok("Paciente deletado!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
