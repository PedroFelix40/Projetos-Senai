using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primeiro_Exemplo.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }

        // Caminho da pasta e do arquivo csv
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            // Criar a lógica para gerar a pasta e o arquivo

            // Obter o caminho da pasta
            string pasta = PATH.Split("/")[0];

            // Verificar se no caminho já existe uma pasta
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Verificar se no caminho já existe um arquivo
            if(!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        // Métodos para ler dados do arquivo csv
        public List<Produto> Ler()
        {   
            // Instância da lista de produtos
            List<Produto> produtos = new List<Produto>();

            // Array de strings armazenando todas as linhas do csv
            string[] linhas = File.ReadAllLines(PATH);

            // Leitura das linhas 
            foreach (var item in linhas)
            {
                // Separação de atributos de cada linha
                string[] atributos = item.Split(";");

                // Instância de produto
                Produto p = new Produto();

                // Atribuição de valores dentro do objeto
                p.Codigo = int.Parse(atributos[0]);
                p.Nome = atributos[1];
                p.Preco = float.Parse(atributos[2]);

                // Adiciona dentro da lista
                produtos.Add(p);
            }
            // Retorna objeto dentro da lista
            return produtos;
        }

        //métodos para preparar as linhas a serem inseridas no csv
        public string PrepararLinhasCsv(Produto p)
        {
            
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //metodo para inserir um produto na linha do csv
        public void inserir(Produto p)
        {
            string[] linhas = {PrepararLinhasCsv(p)};
            
            File.AppendAllLines(PATH, linhas);
        }
    }
}