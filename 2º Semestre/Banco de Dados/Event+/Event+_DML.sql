-- DML

INSERT INTO TiposDeUsuario(TituloTipoUsuario) 
	VALUES('Comum');

INSERT INTO TiposDeEvento(TituloTipoEvento) 
	VALUES('SQL Serve');

INSERT INTO Instituicao(CNPJ,Endereco,NomeFantasia) 
	VALUES('19203948571626','Rua Niterói, 180','DevSchool');

INSERT INTO Usuario(IdTipoDeUsuario,Nome,Email,Senha) 
	VALUES(1,'Pedro','pedro@gmail.com','123');

INSERT INTO Evento(IdTipoDeEvento,IdInstituicao,Nome,Descricao,DataEvento,HorarioEvento)
	VALUES(1,1,'Introdução à Banco de Dados','Este evento tem como intuito levar à todos uma introdução de como funciona o banco de dados','2023-08-11','14:15:00');

INSERT INTO PresencaEvento(IdUsuario,IdEvento,Situacao)
	VALUES(1,1,1);

	SELECT * FROM Evento