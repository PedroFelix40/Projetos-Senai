using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primeiro_Exercício_MVC.Model
{
    public class FestaModel
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Data { get; set; }

        private const string PATH = "Database/Festa.csv";

        public FestaModel()
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
        public List<FestaModel> Ler()
        {
            //instancia da lista
            List<FestaModel> festa = new List<FestaModel>();

            //array para armazenar informação do csv
            string[] linhasCsv = File.ReadAllLines(PATH);

            // leitura
            foreach (var item in linhasCsv)
            {
                // separar os atributos da linha
                string[] atributos = item.Split(";");

                // instancia do convite
                FestaModel f = new FestaModel();

                // Atribuicao dos valores nos indices
                f.Nome = atributos[0];
                f.Descricao = atributos[1];
                f.Data = atributos[2];

                //adiciona na lista
                festa.Add(f);
            }
            return festa;
        }

        //preparar as linhas para mandar para o csv
        public string PrepararLinhasCsv(FestaModel f)
        {
            return $"{f.Nome};{f.Descricao};{f.Data}";
        }

        //inserir os dados n0 csv
        public void Inserir(FestaModel f)
        {
            string[] linhasCsv = {PrepararLinhasCsv(f)};

            File.AppendAllLines(PATH, linhasCsv);
        }
    }
}