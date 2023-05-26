using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exemplo.Controller;
using Primeiro_Exemplo.Model;

namespace Primeiro_Exemplo.View
{
    public class ProdutoView
    {
        //instancia da controler
        ProdutoController produtoController = new ProdutoController();
        // método para exibir os dados da lista no console
        public void Listar(List<ProdutoModel> produtos)
        {
            foreach (var item in produtos)
            {
                Console.WriteLine(@$"
                Código: {item.Codigo}
                Nome: {item.Nome}
                Preço: {item.Preco:C}
                ");
                
            }
        }

        public ProdutoModel Cadastrar()
        {
            ProdutoModel novoProduto = new ProdutoModel();

            Console.WriteLine($"Informe o código: ");
            novoProduto.Codigo = int.Parse(Console.ReadLine()!);
            
            Console.WriteLine($"Informe o nome: ");
            novoProduto.Nome = Console.ReadLine()!;

            Console.WriteLine($"Informe o preço: ");
            novoProduto.Preco = float.Parse(Console.ReadLine()!);

            return novoProduto;
        }

        public void Menu()
        {
            string opcao;
            do
            {
            Console.WriteLine($"MENU DE INGRESSOS");
            Console.WriteLine(@$"
            Selecione a opção desejada:
            [1] - Cadastrar ingresso
            [2] - Listar ingressos
            ");
            opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    produtoController.MandarCsv();
                    break;
                case "2":
                    produtoController.ListarProdutos();
                    break;
            }
              
            } while (opcao != "0");
           
        }
    }
}