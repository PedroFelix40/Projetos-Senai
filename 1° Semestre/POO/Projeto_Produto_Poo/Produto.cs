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
        Marca marca = new Marca();
        public string MarcaP { get; set; }
        public Usuario CadastroPor { get; set; }

        List<Produto> listProdutos = new List<Produto>();

        //metodos
        public Produto()
        {
        }
        public Produto(int codigo, string nomeProduto, float preco, string marca, DateTime dataCadastro)
        {
            Codigo = codigo;
            NomeProduto = nomeProduto;
            Preco = preco;
            DataCadastro = dataCadastro;
            MarcaP = marca;
        }
        public void Cadastrar()
        {
            Console.WriteLine($"Informe o produto: ");
            this.NomeProduto = Console.ReadLine()!;

            Console.WriteLine($"Informe o preço: ");
            this.Preco = float.Parse(Console.ReadLine()!);

            Console.WriteLine($"Informe a marca: ");
            this.MarcaP = Console.ReadLine()!;

            Console.WriteLine($"Informe o código: ");
            this.Codigo = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Produto cadastrado!!");

            DataCadastro = DateTime.Now;
            listProdutos.Add(new(Codigo, NomeProduto, Preco, MarcaP, DataCadastro));
            marca.MarcaAdd(MarcaP);
        }
        public void Listar()
        {
            if (listProdutos.Count == 0)
            {
                Console.WriteLine($"Não há nenhum produto.");

            }
            else
            {
                foreach (var item in listProdutos)
                {
                    Console.WriteLine(@$"
                *******************************
                *Produto: {item.NomeProduto}  
                *Preço: {item.Preco:C}        
                *Marca: {item.MarcaP}
                *Código: {item.Codigo}
                *{item.DataCadastro}
                *******************************
                ");
                }
            }

        }
        public void Deletar(int _codigo)
        {
            if (listProdutos.Count == 0)
            {
                Console.WriteLine($"Não há produtos.");
            }
            else
            {
                Produto p = listProdutos.Find(x => x.Codigo == Codigo)!;
                listProdutos.Remove(p);

                Console.WriteLine($"Produto removido com sucesso.");
            }
        }
    }
}