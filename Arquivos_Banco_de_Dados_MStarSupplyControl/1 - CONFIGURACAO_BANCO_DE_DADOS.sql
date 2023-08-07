--Criando Banco de Dados
CREATE DATABASE DB_MSTARSUPPLY_CONTROL
GO
USE DB_MSTARSUPPLY_CONTROL
GO

CREATE TABLE TB_USUARIOS
(
USUARIO		VARCHAR(20),
NOME		VARCHAR(100),
SENHA		VARCHAR(150)
)
GO

CREATE TABLE TB_MERCADORIAS
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    NOME VARCHAR(50) NOT NULL,
    FABRICANTE VARCHAR(50) NOT NULL,
    TIPO VARCHAR(50) NOT NULL,
    DESCRICAO VARCHAR(200) NOT NULL
)
GO
CREATE TABLE TB_ESTOQUE
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ID_MERCADORIA INT NOT NULL,
	QUANTIDADE INT NOT NULL	
	FOREIGN KEY (ID_MERCADORIA)			 REFERENCES TB_MERCADORIAS(ID)
)
GO
CREATE TABLE LOG_ENTRADA_MERCADORIA
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ID_ESTOQUE INT NOT NULL,
	ID_MERCADORIA INT NOT NULL,
	QUANTIDADE INT NOT NULL,
	DATA_ENTRADA DATE NOT NULL,
	HORA_ENTRADA TIME NOT NULL,
	[LOCAL] VARCHAR(100) NOT NULL
)

CREATE TABLE LOG_SAIDA_MERCADORIA
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ID_ESTOQUE INT NOT NULL,
	ID_MERCADORIA INT NOT NULL,
	QUANTIDADE INT NOT NULL,
	DATA_SAIDA DATE NOT NULL,
	HORA_SAIDA TIME NOT NULL,
	[LOCAL] VARCHAR(100) NOT NULL
)

