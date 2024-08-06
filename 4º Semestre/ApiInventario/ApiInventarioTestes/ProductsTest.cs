using ApiInventario.Domains;
using ApiInventario.Interfaces;
using ApiInventario.Repositories;
using Moq;

namespace ApiInventarioTestes
{
    public class ProductsTest
    {
        /// <summary>
        /// Teste para a funcionalidade de listar todos os produtos
        /// </summary>
        /// 
       private readonly Mock<IProductsRepository> mockRepository = new ();
        [Fact]
        public void Get()
        {
            // Arrange
            List<Products> productList = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name="Produto1", Price=10},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto2", Price=130},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto3", Price=120},
            };

            // Cria um objeto de simulação do tipo repository
            //var mockRepository = new Mock<IProductsRepository>();

            // Configura o método "GetProducts" para que quando for acionado retorne a lista mockada
            mockRepository.Setup(x => x.GetProduts()).Returns(productList);

            // Act

            // Executa o método "GetProducts" e atribue a resposta em result
            var result = mockRepository.Object.GetProduts();

            // Assert
            Assert.Equal(3, result.Count);

        }

        [Fact]
        public void Create()
        {

            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "Arroz", Price = 10 };

            List<Products> listProducts = new List<Products>();

            mockRepository.Setup(x => x.PostProduct(product)).Callback(() => listProducts.Add(product));

            // Act
            // Simula a chamada ao método PostProduct do repositório
            mockRepository.Object.PostProduct(product);

            // Assert
            Assert.Contains(product, listProducts);

        }

        [Fact]
        public void GetById()
        {

            // Arrange
            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "Produto1", Price = 10 };

            List<Products> productList = new List<Products>();

            productList.Add(product);

            mockRepository.Setup(x => x.GetById(product.IdProduct)).Returns(product);

            mockRepository.Object.GetById(product.IdProduct);

            Assert.Contains(product, productList);
        }


        [Fact]
        public void Delete()
        {
            // Arrange
            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "Arroz", Price = 10 };

            List<Products> listProducts = new List<Products>();

            listProducts.Add(product);


            mockRepository.Setup(x => x.DeleteProduct(product.IdProduct)).Callback(() => listProducts.Remove(product));


            // Act  
            mockRepository.Object.DeleteProduct(product.IdProduct);

            // Assert
            Assert.Equal(0,listProducts.Count);

        }

        [Fact]
        public void Put()
        {
            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "Arroz", Price = 10 };
            Products newProduct = new Products { Name = "Arrozin", Price = 10 };

            mockRepository.Setup(x => x.PutProduct(product.IdProduct, newProduct)).Callback(() => product.Name = newProduct.Name);

            mockRepository.Object.PutProduct(product.IdProduct, newProduct);

            Assert.Equal(product.Name, newProduct.Name);
        }

    }

}