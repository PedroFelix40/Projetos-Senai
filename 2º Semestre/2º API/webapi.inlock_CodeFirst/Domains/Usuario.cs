using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email),IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuario é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        //ref. tabela TipoUsuario
        [Required(ErrorMessage = "Tipo do usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }
        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
