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
            try
            {
                Products products = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct)!;

                if (products is not null)
                {
                    _context.Products.Remove(products);
                    _context.SaveChanges();
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Products GetById(Guid id)
        {
            try
            {
                return _context.Products.FirstOrDefault(p => p.IdProduct == id)!;
                
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PutProduct(Guid idProduct, Products product)
        {
            try
            {
                Products products = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct)!;

                if (products is not null)
                {
                    products.Name = product.Name;
                    products.Price = product.Price;

                }
                    _context.Products.Update(products!);
                    _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
