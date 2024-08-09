using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoLivros
{
    public class Livro
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string? nomeLivro;
        public string? autorLivro;
    }
}
