using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Poo
{
    public class Marca
    {
        public int Codigo { get; set; }
        public string NomeMarca { get; set; }
        public DateTime DataCadastro { get; set; }

        public static List<Marca> listMarca = new List<Marca>();

        public Marca()
        {
            
        }
        public Marca(string nomeMarca)
        {
            NomeMarca = nomeMarca;
        }
        public void MarcaAdd(string nomeMarca)
        {
            listMarca.Add(new(nomeMarca));
        }
        public void Cadastrar()
        {
            Console.WriteLine($"Informe uma marca: ");
            this.NomeMarca = Console.ReadLine()!;
            Console.WriteLine($"Informe o código da marca: ");
            this.Codigo = int.Parse(Console.ReadLine()!);
            
            listMarca.Add(new(NomeMarca));
        }
        public void Listar()
        {
            foreach (var item in listMarca)
            {
                Console.WriteLine($"Marca: {item.NomeMarca}");
            }
        }
        public void Remover()
        {
            Marca m = listMarca.Find(x => x.NomeMarca == NomeMarca)!;
            listMarca.Remove(m);

            Console.WriteLine($"Marca removida com sucesso.");
            
        }
        
    }
}