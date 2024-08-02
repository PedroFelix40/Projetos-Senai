using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventarioV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var continuar = "s";
            do
            {
                Console.WriteLine("Informe o nome do produto: ");
                var nomeP = Console.ReadLine();

                Console.WriteLine("Informe a quantidade de produtos: ");
                var qntP = int.Parse(Console.ReadLine());


                //var retorno = Inventario.AdicionarProduto(nomeP, qntP);

                //Console.WriteLine(retorno.Quantidade);

                Console.WriteLine("Deseja continuar adicionando produtos? s/n");
                continuar = Console.ReadLine().ToLower();
            } while (continuar != "n");
            


            inventario.AdicionarProduto("gois", 2);

            // Lista todos os produtos para verificar o resultado
            inventario.ListarProdutos();

            inventario.AdicionarProduto("gois", 3);

            inventario.ListarProdutos();
            */
            
            Inventario inventario = new Inventario();
            
            var continuar = "s";
            do
            {
                Console.WriteLine("Informe o nome do produto: ");
                var nomeP = Console.ReadLine();

                Console.WriteLine("Informe a quantidade de produtos: ");
                var qntP = int.Parse(Console.ReadLine());

                inventario.AdicionarProduto(nomeP, qntP);

                inventario.ExibirProdutoPorNome(nomeP);

                Console.WriteLine("Deseja continuar adicionando produtos? s/n");
                continuar = Console.ReadLine().ToLower();
            } while (continuar != "n");


            Console.WriteLine("Esses são os produtos no inventário: ");

            inventario.ListarProdutos();
        }
    }
}
