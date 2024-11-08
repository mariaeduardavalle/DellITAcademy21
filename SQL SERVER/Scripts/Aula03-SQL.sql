create table estados
( 
     uf     CHAR(2)      NOT NULL, 
     nome   VARCHAR(40) NOT NULL, 
     regiao CHAR(2)      NOT NULL, 
     CONSTRAINT PK_ESTADOS PRIMARY KEY (uf) 
); 

insert into estados
values('RS', 'Rio Grande do Sul', 'S')

insert into estados
values('SC', 'Santa Catarina', 'S')

select * from estados;

CREATE TABLE CIDADES 
( 
     cod_cidade numeric(4)    NOT NULL, 
     nome       VARCHAR(60) NOT NULL, 
     uf         CHAR(2)      NOT NULL, 
     CONSTRAINT PK_CIDADES PRIMARY KEY (cod_cidade) 
);

insert into cidades
values(10, 'Porto Alegre', 'RS');

insert into cidades
values(11, 'Canoas', 'RS');

insert into cidades
values(12, 'Frorianópolis', 'SC');

select * from cidades;

ALTER TABLE CIDADES 
ADD CONSTRAINT FK_EST_CID 
          FOREIGN KEY (uf) 
          REFERENCES ESTADOS (uf) 
;

update estados
set uf = 'RX'
where uf = 'RS';

-- on delete cascade
-- on update cascade

--Que  tipo(s)  de  verificação  de  integridade  seria(m)  necessária(s)  para  (e  entre)  as 
--tabelas PESSOAS e VEICULOS dos exemplos anteriores? 
 
-- 1 criar a coluna cpf_prop em veiculos
alter table pessoas
add cpf_prop varchar(20);

-- 2 adicionar a constraint
alter table pessoas
add constraint pk_pessoas
primary key (cpf);

alter table veiculos
add constraint fk_veiculos_pessoas
foreign key (cpf_prop)
references pessoas(cpf);

-- 3 atualizar os dados para vincular
update veiculos
set cpf_prop = '23363'
where placa = 'IJK-1222';

update veiculos
set cpf_prop = '23363'
where placa = 'XYZ-5678';

------------------------------------------------

create table medicos
(
	crm numeric(6) not null,
	nome varchar(50) not null,
	especialidade varchar(50)not null,
	CONSTRAINT PK_MEDICOS PRIMARY KEY (crm)
);

create table pacientes
(
	cpf numeric(11) not null,
	nome varchar(50) not null,
	sexo char(1) not null,
	CONSTRAINT PK_PACIENTES PRIMARY KEY(cpf)
);

create table medicospacientes
(
	cpf_p numeric(11)not null,
	crm_m numeric(6) not null,
	CONSTRAINT PK_MEDICOPACIENTE PRIMARY KEY(CPF_P, CRM_M),
	CONSTRAINT FK_MED_PAC FOREIGN KEY(CRM_M) REFERENCES medicos(crm),
	CONSTRAINT FK_PAC_MED FOREIGN KEY(CPF_P) REFERENCES PACIENTES(CPF)
	
);

create table consulta
(
	Id_c numeric not null,
	dataconsulta date not null, 
	cpf_p numeric(11)not null,
	crm_m numeric(6) not null,
	CONSTRAINT PK_Consulta PRIMARY KEY(Id_c),
	CONSTRAINT FK_M_Consulta FOREIGN KEY(CRM_M) REFERENCES medicos(crm),
	CONSTRAINT FK_P_Consulta FOREIGN KEY(CPF_P) REFERENCES PACIENTES(CPF)
);

insert into medicos
values(123456,'José', 'Otorrino' );

insert into pacientes
values(98765432198, 'Maria', 'F');

insert into medicos
values(123457,'Carlos', 'Gineco' );

insert into pacientes
values(98765432112, 'Renata', 'F');

insert into consulta
values(1, '14-FEB-2024', 98765432198, 123456);

insert into consulta
values(2, '14-DEC-2024', 98765432198, 123456);

insert into consulta
values(3, '03-NOV-2024', 98765432112, 123457);

select * from consulta;

alter table consulta
add constraint  AK_M_DATA UNIQUE (crm_m, dataconsulta);

alter table consulta
add constraint AK_P_DATA UNIQUE(cpf_p, dataconsulta);

----------------------------------
--CROSS JOIN
-----------------------------------
-- JEITO ANTIGO

select *
from estados, cidades
where estados.uf = cidades.uf;
---------------------------------------
-- forma mais moderna

select *
from cidades INNER join estados
on cidades.uf = estados.uf
where estados.uf = 'RS';

-- nome do paciente, nome do médico
-- ordenado pelo nome do paciente

select pacientes.nome as NomePaciente, medicos.nome as NomeMedico
from medicos, pacientes, consulta
where medicos.crm = consulta.crm_m
and pacientes.cpf = consulta.cpf_p
order by pacientes.nome;