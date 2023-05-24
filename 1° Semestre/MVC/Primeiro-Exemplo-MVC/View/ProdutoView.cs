using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exemplo.Model;

namespace Primeiro_Exemplo.View
{
    public class ProdutoView
    {
        // método para exibir os dados da lista no console
        public void Listar(List<Produto> produtos)
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
    }
}