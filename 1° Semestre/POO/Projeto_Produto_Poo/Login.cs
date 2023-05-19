using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Login
    {
        //propriedades
        public bool Logado { get; set; }

        //metodos
        public Login()
        {
            Usuario user = new Usuario();

            Logar(user);

            if (Logado == true)
            {
                Menu();
            }
        }

        // validando email e senha com if
        public bool Logar(Usuario _usuario)
        {
            string email;
            string senha;
            do
            {
                Console.WriteLine($"Insira seu email: ");
                email = Console.ReadLine()!;

                Console.WriteLine($"Insira seu senha: ");
                senha = Console.ReadLine()!;

                if (email == _usuario.Email && senha == _usuario.Senha)
                {
                    this.Logado = true; // acesso permitido
                    Console.WriteLine($"VOCÊ ESTÁ LOGADO!!");
                }
                else
                {
                    this.Logado = false;
                    Console.WriteLine($"Erro ao logar - Usuário ou senha incorreto");

                }
            } while (email != _usuario.Email || senha != _usuario.Senha);
            return Logado;

        }
        public void deslogar(Usuario _usuario)
        {
            Logado = false;
        }

        public void Menu()
        {
            Produto produto = new Produto();
            Marca marca = new Marca();
            string opcao;
            int codigoProd;


            do
            {
                Console.WriteLine(@$"
             ╔════════════════════════╗
             ║     Bem-vindo(a)!      ║
             ║   Escolha uma opção:   ║
             ║                        ║
             ║  1 - Cadastrar Produto ║
             ║  2 - Listar Produto    ║
             ║  3 - Remover Produto   ║
             ║  4 - Cadastrar Marca   ║
             ║  5 - Listar Marca      ║
             ║  6 - Remover Marca     ║
             ║  0 - Sair              ║
             ╚════════════════════════╝
            ");
                opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        produto.Cadastrar();
                        break;
                    case "2":
                        produto.Listar();
                        break;
                    case "3":
                        Console.WriteLine($"Informe o código do produto a ser excluído: ");
                        codigoProd = int.Parse(Console.ReadLine()!);

                        produto.Deletar(codigoProd);
                        break;
                    case "4":
                        marca.Cadastrar();
                        break;
                    case "5":
                        marca.Listar();
                        break;
                    case "6":
                        marca.Remover();
                        break;
                }
            } while (opcao != "0");


        }
    }
}