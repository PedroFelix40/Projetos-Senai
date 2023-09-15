using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo é obrigatório!")]
        public string? Nome { get; set; }
        
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do jogo é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatória!")]
        public Decimal preco { get; set; }

        //ref. tabela estudio - FK
        public Guid IdEstudio { get; set; }
        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
