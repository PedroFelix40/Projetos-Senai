using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public float Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public Marca Marca = new Marca();
        public Usuario CadastroPor { get; set; }

        List<Produto> listProdutos = new List<Produto>();

        //metodos
        public Produto()
        {
        }
        public Produto(int codigo, string nomeProduto, float preco, string marca)
        {
            Codigo = codigo;
            NomeProduto = nomeProduto;
            Preco = preco;
            Marca.NomeMarca = marca;
        }
        public void Cadastrar()
        {
            Console.WriteLine($"Informe o produto: ");
            this.NomeProduto = Console.ReadLine()!;

            Console.WriteLine($"Informe o preço: ");
            this.Preco = float.Parse(Console.ReadLine()!);

            Console.WriteLine($"Informe a marca: ");
            Marca.NomeMarca = Console.ReadLine()!;

            Console.WriteLine($"Informe o código: ");
            this.Codigo = int.Parse(Console.ReadLine()!);
            
            
            listProdutos.Add(new(Codigo, NomeProduto, Preco, Marca.NomeMarca));

        }
        public void Listar()
        {
            foreach (var item in listProdutos)
            {
                Console.WriteLine(@$"
                Produto: {item.NomeProduto}
                Preço: {item.Preco}
                Marca: {item.Marca.NomeMarca}
                Código: {item.Codigo}
                ");
            }
        }
        public void Deletar(int _codigo)
        {

        }


    }
}