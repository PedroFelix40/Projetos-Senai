using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exemplo.Model;
using Primeiro_Exemplo.View;

namespace Primeiro_Exemplo.Controller
{
    public class ProdutoController
    {
        // Instancia das classes produto e produtoView
        ProdutoModel produtoModel = new ProdutoModel();
        ProdutoView produtoView = new ProdutoView();
        
        // Método controlador para acessar a listagem de produtos
        public void ListarProdutos()
        {
            //chamada da model trazendo a lista
            List<ProdutoModel> produtos = produtoModel.Ler();
            
            //chamada da view passando a lista
            produtoView.Listar(produtos);
        }

        public void MandarCsv()
        {
            produtoModel.inserir(produtoView.Cadastrar());
            Console.WriteLine($"Produto Cadastrado com sucesso.");
            
        }

        public void MostrarMenu()
        {
            produtoView.Menu();
        }
    }
}