using ApiInventario.Interfaces;
using ApiInventario.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                return Ok(_products.GetProduts());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
