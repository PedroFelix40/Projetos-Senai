using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O expediente é obrigatório!")]
        public string? Expediente { get; set; }
        
        [Column(TypeName = "CHAR(6)")]
        [Required(ErrorMessage = "O CRM é obrigatório!")]
        [StringLength(6)]
        public string? CRM { get; set; }

        //ref. tabela Clinica
        [Required(ErrorMessage = "A clinica é obrigatório!")]
        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        //ref. tabela Especialidade
        [Required(ErrorMessage = "A especialidade é obrigatório!" )]
        public Guid IdEspecialidade { get; set; }
        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //ref. tabela Usuario
        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
