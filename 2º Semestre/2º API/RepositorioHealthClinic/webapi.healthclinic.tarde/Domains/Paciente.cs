using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]


    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O telefone do paciente é obrigatório!")]
        [StringLength(9)]
        public string? Telefone { get; set; }

        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O RG do paciente é obrigatório!")]
        [StringLength(9)]
        public string? RG { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF do paciente é obrigatório!")]
        [StringLength(11)]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço do paciente é obrigatório!")]
        public string? Endereco { get; set; }

        //ref. tabela Usuario
        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
