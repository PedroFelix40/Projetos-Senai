using ApiInventario.Contexts;
using ApiInventario.Domains;
using ApiInventario.Interfaces;

namespace ApiInventario.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly InventarioContext _context;
        public ProductsRepository()
        {
            _context = new InventarioContext();
        }

        public void DeleteProduct(Guid idProduct)
        {
            throw new NotImplementedException();
        }

        public Products GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProduts()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PostProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public void PutProduct(Guid idProduct, Products product)
        {
            throw new NotImplementedException();
        }
    }
}
