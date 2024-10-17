--Criação do banco
Create database dev_db_tarde
go

use dev_db_tarde
go


--Criação das tabelas
create table Professor(
ProfessorId int primary key identity,
Nome varchar(255),
Email varchar(255) unique,
Senha varchar(255),
)
go

create table Turma(
TurmaId int primary key identity,
Nome varchar(255),
ProfessorId int foreign key references Professor(ProfessorId)
)
go

create table Atividade(
AtividadeId int primary key identity,
Descricao varchar(255),
TurmaId int foreign key references Turma(TurmaId)
)
go


--Inserção de dados na tabela

Insert into Professor(Nome,Email,Senha) Values 
('Carlos', 'carlos@email.com', '12345'),
('Miguel', 'miguel@email.com', '12345'),
('Sampaio', 'sampaio@email.com', '12345')
go

Insert into Turma (Nome, ProfessorId) values
('Dev 2025', 1),
('Redes 2025', 2),
('Mult 2025', 3)
go

Insert into Atividade(Descricao, TurmaId) values
('Lógica de Programação', 1),
('IOT', 2),
('Photoshop', 3)