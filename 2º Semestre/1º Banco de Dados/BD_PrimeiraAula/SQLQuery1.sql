--DDL - DATA DEFINITION LANGUAGE

-- Cria Banco de Dados
CREATE DATABASE BancoTarde;

-----------------------------------------
-- Use o Bando de Dados
USE BancoTarde;

-----------------------------------------
-- Cria tabelas
CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20)
);

CREATE TABLE Empresas
(
	IdEmpresa INT PRIMARY KEY IDENTITY,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
	Nome VARCHAR(20)
);

--------------------------------------
-- ALTER TABLE
ALTER TABLE Funcionarios
ADD Cpf VARCHAR(11)

ALTER TABLE Funcionarios
DROP COLUMN Cpf

DROP TABLE Empresas;

DROP DATABASE BancoTarde

