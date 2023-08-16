-- DQL 

-- - Id Consulta
-- Data da Consulta
-- Horario da Consulta
-- Nome da Clinica
-- Nome do Paciente
-- Nome do Medico
-- Especialidade do Medico
-- CRM
-- Prontu�rio ou Descricao
-- FeedBack(Comentario da consulta)

-- Criar fun��o para retornar os m�dicos de uma determinada especialidade

-- *Criar procedure para retornar a idade de um determinado usu�rio espec�fico

SELECT 
	Consulta.IdConsulta AS [Ficha],
	Consulta.Dia AS [Data],
	Consulta.Hora AS [Horario],
	Clinica.NomeFantasia AS [Nome da clinica],
	[Nome do Paciente].Nome AS [Nome do Paciente],
	[Nome do Medico].Nome AS [Nome do Medico],
	Especialidade.Especialidade AS [Especialidade do m�dico],
	Consulta.Prontuario
	--Comentario.Comentario AS [FeedBack]
FROM
	Consulta
INNER JOIN Medico
ON Medico.IdMedico = Consulta.IdMedico

INNER JOIN Clinica
ON Medico.IdClinica = Clinica.IdClinica

INNER JOIN Usuario AS [Nome do Medico]
ON Medico.IdUsuario = [Nome do Medico].IdUsuario

INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdPaciente

INNER JOIN Usuario AS [Nome do Paciente]
ON Paciente.IdUsuario = [Nome do Paciente].IdUsuario

INNER JOIN Especialidade
ON Medico.IdEspecialidade = Especialidade.IdEspecialidade


CREATE FUNCTION VerEspecialidade
(
	@Especialidade VARCHAR(30)
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		Usuario.Nome AS 'Nome do M�dico',
		Especialidade.Especialidade AS 'Especializa��o'
	FROM
		Especialidade
	INNER JOIN Medico
	ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	INNER JOIN Usuario
	ON Usuario.IdUsuario = Medico.IdUsuario
	WHERE Especialidade.Especialidade = @Especialidade
);

-- Execu��o do m�todo de Busca de M�dicos por especialidade: VerEspecialidade
SELECT *
FROM VerEspecialidade('Urologista');
