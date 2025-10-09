create database saem_bd;
use saem_bd;

create table instrumento (
id_ins int primary key auto_increment,
nome_ins varchar(50),
tipo_ins varchar(50)
);

create table curso (
id_cur int primary key auto_increment,
nome_cur varchar(100) not null,
nivel_dificuldade_cur varchar(20),
descricao_cur varchar(200),
id_ins_fk int not null,
foreign key(id_ins_fk) references Instrumento(id_ins)
);

create table turma (
id_tur int primary key auto_increment,
nome_tur varchar(100),
vagas_tur int,
status_tur varchar(20),
data_inicial_tur date,
data_final_tur date,

id_cur_fk int,
foreign key (id_cur_fk) references curso (id_cur)
);


create table professor (
id_pro int primary key auto_increment,
cpf_pro varchar(20),
nome_pro varchar(100),
data_nascimento_pro date,
email_pro varchar(50),
telefone_pro varchar(30),
cep_pro varchar(20)
);

create table aluno (
id_alu int primary key auto_increment,
cpf_alu varchar(20),
nome_alu varchar(100),
data_nascimento_alu date,
email_alu varchar(100),
telefone_alu varchar(30),
cep_alu varchar(20)
);

create table mensalidade (
id_men int primary key auto_increment,
valor_integral_men double,
porcentagem_desconto_men double,
valor_final_men double,
id_alu_fk int not null,
id_cur_fk int not null,
foreign key(id_alu_fk) references Aluno(id_alu),
foreign key(id_cur_fk) references Curso(id_cur)
);

create table aula (
id_aul int primary key auto_increment,
nome_aul varchar(50),
data_aul date,
horario_aul time,
id_tur_fk int not null,
id_cur_fk int not null,
id_pro_fk int not null,
foreign key(id_tur_fk) references Turma(id_tur),
foreign key(id_cur_fk) references Curso(id_cur),
foreign key(id_pro_fk) references Professor(id_pro)
);