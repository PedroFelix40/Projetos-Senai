using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Produto
    {
       private int Codigo { get; set; }
       private string NomeProduto { get; set; }
       private float Preco { get; set; }
       private DateTime DataCadastro;
       private  Marca Marca;
       private Usuario CadastroPor;
       private  List<Produto> ListaDeProdutos = new List<Produto>();

       //metodos
    //    public string Cadastrar(Produto _produto)
    //    {
    //     return "";
    //    }

       
    }
}