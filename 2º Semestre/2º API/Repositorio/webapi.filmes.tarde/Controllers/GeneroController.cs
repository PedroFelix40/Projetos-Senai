using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de api
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos métodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint q acessa o metodo listar generos
        /// </summary>
        /// <returns>Lista de generos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os generos
                List<GeneroDomain> listasGeneros = _generoRepository.ListarTodos();

                //Retorna os statusCode 200 ok e a lista de generos no formato json
                return Ok(listasGeneros);
                //return ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que acessa o metodo cadastrar 
        /// </summary>
        /// <returns>status code</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                // faz a chamada para o metodo cadastrar
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um statusCode 201 ok
                return Created("Objeto criado", novoGenero);
                //return StatusCode(201);
            }
            catch (Exception erro)
            {

                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /*
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                // faz a chamada para o metodo deletar
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
        */

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /*
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                GeneroDomain generoDomain = _generoRepository.BuscarPorId(id);

                return Ok(generoDomain);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        */

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("O gênero buscado não foi encontrado.");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutById(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, genero);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
