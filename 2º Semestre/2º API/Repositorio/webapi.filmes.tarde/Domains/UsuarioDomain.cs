using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Filme
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "o email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength = 3, ErrorMessage = "O campo senha precisa de no mínimo 3 e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
