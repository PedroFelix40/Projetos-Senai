using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O comentario é obrigatório!")]
        public string? FeedBack { get; set; }

        //ref. tabela CLinica
        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        //ref. tabela usuario
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
