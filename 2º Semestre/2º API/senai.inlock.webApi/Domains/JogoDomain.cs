namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Jogo
    /// </summary>
    public class JogoDomain
    {
        /*
         *IdJogo INT PRIMARY KEY IDENTITY
	    ,IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
	    ,Nome VARCHAR(100) NOT NULL
	    ,Descricao VARCHAR(100) NOT NULL
	    ,DataLancamento DATE NOT NULL
	    ,Valor SMALLMONEY NOT NULL
         */

        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public EstudioDomain? estudioDomain { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string DataLancamento { get; set; }
        public decimal Valor { get; set; }
    }
}
