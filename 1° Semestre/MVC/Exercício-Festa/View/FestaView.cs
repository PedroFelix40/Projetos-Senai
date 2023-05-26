using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exercício_MVC.Controller;
using Primeiro_Exercício_MVC.Model;

namespace Primeiro_Exercício_MVC.View
{
    public class FestaView
    {
        FestaController festaController = new FestaController();
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
            [0] - Sair
            ");
                opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        festaController.CadNoCsv();
                        break;
                    case "2":
                        festaController.ListaIngressos();
                        break;
                }
            } while (opcao != "0");

        }
    }
}