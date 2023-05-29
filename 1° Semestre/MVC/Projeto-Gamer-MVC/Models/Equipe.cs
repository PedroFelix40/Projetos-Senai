using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Gamer_MVC.Models
{
    public class Equipe
    {
        [Key]
        public int IdEquipe { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }

        public ICollection<Jogador>? Jogador { get; set; }
    }
}