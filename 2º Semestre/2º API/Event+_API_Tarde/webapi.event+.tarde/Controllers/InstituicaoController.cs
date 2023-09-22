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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// EndPoint Atualizar
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return NotFound("Instituição não encontrada");
                }

                _instituicaoRepository.Atualizar(id, instituicao);

                return Ok(instituicao);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint buscarPorId
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return NotFound("Instituição não encontrada");
                }
                return Ok(instituicaoBuscada);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Deletar
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return NotFound("Instituição não encontrada");
                }

                _instituicaoRepository.Deletar(id);

                return Ok("Instituição deletada");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint Listar
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_instituicaoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
