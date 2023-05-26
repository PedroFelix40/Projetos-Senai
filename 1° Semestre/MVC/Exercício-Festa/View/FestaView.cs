using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exercício_MVC.Model;

namespace Primeiro_Exercício_MVC.View
{
    public class FestaView
    {
        //metodo de listar
        public void Listar(List<FestaModel> festa)
        {
            foreach (var item in festa)
            {    
            Console.WriteLine(@$"
            Nome: {item.Nome}
            Descrição: {item.Descricao}
            Data: {item.Data}
            ");
            }    
        }

        public FestaModel Cadastrar()
        {
            FestaModel novoIngresso = new FestaModel();

            Console.WriteLine($"Informe seu nome: ");
            novoIngresso.Nome = Console.ReadLine()!;

            Console.WriteLine($"Informe uma descrição: ");
            novoIngresso.Descricao = Console.ReadLine()!;

            Console.WriteLine($"Informe a data do evento: 00/00/0000");
            novoIngresso.Data = Console.ReadLine()!;
            
            return novoIngresso;
        }
    }
}