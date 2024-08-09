using ApiInventario.Domains;
using ApiInventario.Interfaces;
using ApiInventario.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ApiInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _products;

        public ProductsController()
        {
            _products = new ProductsRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Products> list = _products.GetProduts();

                if (list == null)
                {
                    return NotFound("Não há nenhum produto na lista!");
                }

                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Products products)
        {
            try
            {
                _products.PostProduct(products);

                return StatusCode(200, products);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("idProduct")]
        public IActionResult GetByIdProduct(Guid idProduct)
        {
            try
            {
                var returnProduct = _products.GetById(idProduct);

                return returnProduct != null ? StatusCode(200, returnProduct) : NotFound("Produto não encontrado!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("idProduct")]
        public IActionResult DeleteByIdProduct(Guid idProduct)
        {
            try
            {
                var returnProduct = _products.GetById(idProduct);
                if (returnProduct == null)
                {
                    return NotFound("Produto não foi encontrado!");
                }

                _products.DeleteProduct(idProduct);

                return StatusCode(200, "O produto foi excluido com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("idProduct")]
        public IActionResult PutProduct(Guid idProduct, Products products)
        {
            try
            {
                var productReturn = _products.GetById(idProduct);

                if (productReturn == null)
                {
                    return NotFound("Objeto não encontrado!");
                }

                _products.PutProduct(idProduct, products);
                return Ok(products);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
