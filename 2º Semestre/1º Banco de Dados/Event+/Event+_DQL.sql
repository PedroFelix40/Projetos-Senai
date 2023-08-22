-- DQL -- Data Query Language

SELECT
	Usuario.Nome AS Nome,
	TiposDeUsuario.TituloTipoUsuario AS [Tipo de Usu�rio],
	Evento.DataEvento AS [Data do evento],
	'Escola ' + Instituicao.NomeFantasia + ', ' + Instituicao.Endereco AS [Endere�o],
	TiposDeEvento.TituloTipoEvento AS [Tipo de evento],
	Evento.Nome AS [Nome do evento],
	Evento.Descricao AS [Descri��o do evento],
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmado' ELSE 'N�o confirmado' END AS [Situa��o],
	ComentarioEvento.Descricao AS [Coment�rios]
FROM 
	PresencaEvento
INNER JOIN Usuario
ON PresencaEvento.IdUsuario = Usuario.IdUsuario
INNER JOIN TiposDeUsuario
ON Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
INNER JOIN Evento
ON PresencaEvento.IdEvento = Evento.IdEvento
INNER JOIN Instituicao
ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TiposDeEvento
ON Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
LEFT JOIN ComentarioEvento
ON Usuario.IdUsuario = ComentarioEvento.IdUsuario