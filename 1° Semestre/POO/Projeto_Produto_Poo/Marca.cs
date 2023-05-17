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

        List<Marca> listMarca = new List<Marca>();

        public Marca Cadastrar()
        {
            Marca novaMarca = new Marca();

            return novaMarca;
        }
        public Marca Listar()
        {
            Marca novaMarca = new Marca();

            return novaMarca;
        }
        public Marca Remover()
        {
            Marca novaMarca = new Marca();

            return novaMarca;
        }
        
    }
}