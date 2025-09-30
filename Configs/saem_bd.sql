create database saem_bd;
use saem_bd;

create table instrumento (
id_ins int primary key auto_increment,
nome_ins varchar(200),
tipo_ins varchar(200)
);

create table turma (
id_tur int primary key auto_increment,
nome_tur varchar(200),
vagas_tur int,
status_tur varchar(200),
data_inicial_tur date,
data_final_tur date
);

create table curso (
id_cur int primary key auto_increment,
nome_cur varchar(200),
nivel_dificuldade_cur varchar(200),
descricao_cur varchar(300),
id_ins_fk int not null,
id_tur_fk int not null,
foreign key(id_ins_fk) references Instrumento(id_ins),
foreign key(id_tur_fk) references Turma(id_tur)
);

create table professor (
id_pro int primary key auto_increment,
cpf_pro varchar(100),
nome_pro varchar(200),
data_nascimento_pro date,
foto_perfil_pro blob,
email_pro varchar(200),
telefone_pro varchar(100),
cep_pro varchar(200),
instrumentos_pro varchar(300),
id_ins_fk int not null,
id_cur_fk int not null,
foreign key(id_ins_fk) references Instrumento(id_ins),
foreign key(id_cur_fk) references Curso(id_cur)
);

create table aluno (
id_alu int primary key auto_increment,
cpf_alu varchar(100),
nome_alu varchar(200),
data_nascimento_alu date,
foto_perfil_alu blob,
email_alu varchar(200),
telefone_alu varchar(100),
cep_alu varchar(200),
id_tur_fk int not null,
id_cur_fk int not null,
foreign key(id_tur_fk) references turma(id_tur),
foreign key(id_cur_fk) references curso(id_cur)
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
nome_aul varchar(200),
data_aul date,
horario_aul time,
id_tur_fk int not null,
id_cur_fk int not null,
id_pro_fk int not null,
foreign key(id_tur_fk) references Turma(id_tur),
foreign key(id_cur_fk) references Curso(id_cur),
foreign key(id_pro_fk) references Professor(id_pro)
);