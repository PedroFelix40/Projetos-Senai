-- DQL -- Data Query Language

SELECT
	Usuario.Nome AS Nome,
	TiposDeUsuario.TituloTipoUsuario AS [Tipo de Usuário],
	Evento.DataEvento AS [Data do evento],
	'Escola ' + Instituicao.NomeFantasia + ', ' + Instituicao.Endereco AS [Endereço],
	TiposDeEvento.TituloTipoEvento AS [Tipo de evento],
	Evento.Nome AS [Nome do evento],
	Evento.Descricao AS [Descrição do evento],
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não confirmado' END AS [Situação],
	ComentarioEvento.Descricao AS [Comentários]
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