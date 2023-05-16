using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Login
    {
        //propriedades
        private bool Logado { get; set; }

        //metodos
        // public Login()
        // {
        // }

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
                    Logado = true; // acesso permitido
                    Console.WriteLine($"VOCÊ ESTÁ LOGADO!!");
                }
                else
                {
                    Console.WriteLine($"Erro ao logar - Usuário ou senha incorreto");

                }
            } while (email != _usuario.Email && senha != _usuario.Senha);
            return true;

        }
        public void deslogar(Usuario _usuario)
        {
            Logado = false;
        }
        
        public Login()
        {
            Usuario user = new Usuario();
            Logar(user);

            if (Logado == true)
            {
                GerarMenu();
            }
        }

        public void GerarMenu()
        {
            
            Console.WriteLine(@$"
            *****MENU DE OPÇÕES*****

            ----ESCOLHA A OPÇÃO----
            [1] - CADASTRAR PRODUTO
            [2] - LISTAR PRODUTOS
            [3] - REMOVER PRODUTO
            [4] - CADASTRAR MARCA
            [5] - LISTAR MARCA
            [6] - REMOVER MARCA
            [0] -  SAIR
            ");
            
        }
    }
}