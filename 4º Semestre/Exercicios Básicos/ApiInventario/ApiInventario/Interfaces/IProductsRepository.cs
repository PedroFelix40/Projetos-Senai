using ApiInventario.Domains;

namespace ApiInventario.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> GetProduts();
        Products GetById(Guid id);
        void PostProduct(Products product);
        void PutProduct(Guid idProduct, Products product);
        void DeleteProduct(Guid idProduct);
    }
}
