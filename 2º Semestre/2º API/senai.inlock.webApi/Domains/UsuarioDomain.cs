using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        /*
         IdUsuario INT PRIMARY KEY IDENTITY
	    ,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
    	,Email VARCHAR(100) NOT NULL UNIQUE
	    ,Senha VARCHAR (100) NOT NULL
         */
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuarioDomain? tipoUsuarioDomain { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string? Senha { get; set; }
    }
}
