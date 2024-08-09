using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventarioV2
{
    public class Inventario
    {
        private List<Produto> produtos;

        public Inventario()
        {
            produtos = new List<Produto>();
        }
        public void AdicionarProduto(string nome, int quantidade)
        {
            try
            {
                var produtoExistente = produtos.Find(p => p.Nome == nome);

                if (produtoExistente != null) 
                {
                    produtoExistente.Quantidade += quantidade;
                }
                else
                {
                    produtos.Add(new Produto(nome, quantidade));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ListarProdutos()
        {
            try
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ExibirProdutoPorNome(string nome)
        {
            try
            {
                var produto = produtos.Find(p => p.Nome == nome);
                if (produto != null)
                {
                    Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
