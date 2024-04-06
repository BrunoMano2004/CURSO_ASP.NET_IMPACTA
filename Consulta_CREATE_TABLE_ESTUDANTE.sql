use Projeto06;

create table Estudante(
	Estudante_Id INT IDENTITY(1, 1) NOT NULL,	
	Estudante_Nome VARCHAR(50) NOT NULL,
	Estudante_Sobrenome VARCHAR(100) NOT NULL,
	Estudante_RA NUMERIC,
	Estudante_Email VARCHAR(30),
	Estudante_Idade INT,
	Estudante_Fone VARCHAR(30),
	Estudante_Genero VARCHAR(30)
	CONSTRAINT Estudante_PK PRIMARY KEY(Estudante_Id)
)