using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Gamer_MVC.Models
{
    public class Jogador
    {

        [Key] // o "key" serve como um identificador
        public int IdJogador { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        [ForeignKey("Equipe")] // Para referenciar a class Equipe
        public int IdEquipe { get; set; }
        public Equipe? Equipe { get; set; }
    }
}