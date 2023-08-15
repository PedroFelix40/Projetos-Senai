-- DML 

USE HealthClinic

-- INSERT INTO Clinica(NomeFantasia,RazaoSocial,CNPJ,Endereco,HorarioAbertura,HorarioEncerramento)
	-- VALUES('Health Clinic','Health Clinic','12345678900987','R. Niterói, 180 - SCS','06:00','21:00')

-- INSERT INTO Usuario(Nome,Senha,Email,DataNascimento)
	-- VALUES('Enzo','123','Enzo@gmail.com')

-- INSERT INTO Usuario(Nome,Senha,Email,DataNascimento)
	-- VALUES('Gustav','123','gustav@gmail.com')

-- INSERT INTO Especialidade(Especialidade)
	-- VALUES('Urologista')

-- INSERT INTO Medico(IdClinica,IdEspecialidade,IdUsuario,Expediente)
	-- VALUES(1,1,1,'Noturno')

-- INSERT INTO Paciente(IdUsuario,Telefone,RG,CPF,Endereco)
	-- VALUES(2,'11990990','123456789','45678901234','R. Senai, 123 - SP')

-- INSERT INTO Consulta(IdMedico,IdPaciente,Dia,Hora,Prontuario)
	-- VALUES(1,1,'2023-08-17','17:00','O paciente está em perfeito estado para trabalhar')

INSERT INTO Comentario(IdClinica,IdUsuario,Comentario)
	VALUES(1,2,'Adorei o atendimento!!')