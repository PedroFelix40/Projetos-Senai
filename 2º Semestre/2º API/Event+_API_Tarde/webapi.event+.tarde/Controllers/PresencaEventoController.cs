﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// EndPoint Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.BuscarPorId(id);

                if (presencaEventoBuscado == null)
                {
                    return NotFound("Presença evento não encontrada!");
                }

                _presencaEventoRepository.Atualizar(id, presencaEvento);

                return Ok(presencaEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
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
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.BuscarPorId(id);

                if (presencaEventoBuscado == null)
                {
                    return NotFound("Presença evento não encontrada!");
                }

                return Ok(presencaEventoBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Cadastrar
        /// </summary>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presencaEvento);

                return Ok(presencaEvento);
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
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.BuscarPorId(id);

                if (presencaEventoBuscado == null)
                {
                    return NotFound("Presença evento não encontrada!");
                }

                _presencaEventoRepository.Deletar(id);

                return Ok("Presença evento deletada!");
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
                return Ok(_presencaEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
