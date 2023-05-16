using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Usuario
    {
        //propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } = "pedro@";
        public string Senha { get; set; } = "123";
        public DateTime DataCadastro;

        //metodos
        public string Cadastrar()
        {
            return "";
        }
        
        public string Deletar()
        {
            return "";
        }


    }
}