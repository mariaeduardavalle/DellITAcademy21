select *
from usuarios
where cod_usuario = 10;


select USU.nome, CLI.data_nascimento
from clientes CLI join usuarios USU
on CLI.cod_cliente = USU.cod_usuario
where USU.cod_usuario = 10;

-- obter título e autor dos produtos que iniciam com S, em ordem alfabética de autor

select P.titulo, A.nome
from produtos P join autores_produtos AP
on P.cod_produto = AP.cod_produto
join autores A on A.cod_autor = AP.cod_autor 
where P.titulo like 'S%'
order by A.nome;

-- nomes dos clientes e seus telefones, ordenados por nome

select U.nome, T.ddd, T.numero
from usuarios U JOIN clientes C
ON U.cod_usuario = C.cod_cliente
JOIN telefones T
on C.cod_cliente = T.cod_cliente
order by U.nome;

---------------------------
-- novo cliente

insert into usuarios
values (283, 'Daniel', '11111111', 'daniel@', 'daniel', '1234');

insert into clientes
values (283, convert(date, '27/09/2003', 103), convert(date, '23/09/2023',103));

insert into telefones
values(283, 28, 1, 51, 987868563);

delete from telefones
where cod_telefone = 28;

-------------------------------------------
-- exercicios
-------------------------------------------

-- 1

select P.titulo, A.nome, P.importado
from produtos P join autores_produtos AP
ON P.cod_produto = AP.cod_produto
join autores A on AP.cod_autor = A.cod_autor
WHERE P.importado = 'S'
order by P.titulo;


-- 2

SELECT count(*) AS QUANTIDADE
from cidades C join estados E
on C.uf = E.uf
where E.uf = 'SP';


-- 3
select U.nome, U.email, T.ddd, T.numero
from usuarios U join clientes C
on U.cod_usuario = C.cod_cliente
join telefones T ON c.cod_cliente = t.cod_cliente
where T.ddd = 51;


-- 4
 select C.cod_cidade, C.nome, E.regiao
 from cidades C join estados E
 on C.uf = E.uf
 where E.uf IN ('RS', 'SP', 'PE') and C.nome like 'Santa%'
 order by C.nome desc;

 --5
select distinct A.nome, estados.regiao
from autores A join autores_produtos AP
on A.cod_autor = AP.cod_autor
join produtos P on AP.cod_produto = p.cod_produto
join pedidos_produtos PP on P.cod_produto = PP.cod_produto
join pedidos PE on PE.num_pedido = PP.num_pedido
join enderecos E on E.cod_endereco = PE.cod_endereco
join cidades C on C.cod_cidade = E.cod_cidade
join estados on estados.uf = C.uf
where regiao = 'N'
ORDER BY A.nome;


 -----------------------------------------------------------------------------
 -- VIEW

 create view produto_importado as
 select cod_produto, titulo, preco, prazo_entrega
 from produtos
 where importado = 'S';


 select * from produto_importado;

 create view produto_importado_dolares as
 select cod_produto, titulo, round(preco/5.76, 2) as dolares
 from produto_importado;

 select * from produto_importado_dolares;

 select *
 from produto_importado_dolares join autores_produtos
 on produto_importado_dolares.cod_produto = autores_produtos.cod_produto
 join autores on autores.cod_autor = autores_produtos.cod_autor;

 ----------------- SEGURANÇA
 create view clientes_ativos as
 select clientes.cod_cliente, usuarios.nome, usuarios.email, clientes.data_nascimento
 from usuarios join clientes
 on usuarios.cod_usuario = clientes.cod_cliente;

 select * from clientes_ativos;

 ---------------------------
 -- MEDIA

 select avg(preco)
 from produtos
 where titulo like 'T%';

 ---------------------------------------
 -- GROUP BY
 select uf, count(*) as quantidade
 from cidades
 group by uf;

 --------------------------------------------------

 CREATE TABLE PRODS
(
 codigo NUMERIC(3) NOT NULL,
 nome VARCHAR(50) NOT NULL,
 preco NUMERIC (5,2) NOT NULL,
 tipo CHAR(1) NULL, 
 -- [S]uprimento, [C]omponente, [P]eriférico
 CONSTRAINT PK1 PRIMARY KEY (codigo)
);

INSERT INTO PRODS 
VALUES( 10, 'HD', 200, 'C');
INSERT INTO PRODS 
VALUES( 11, 'Memoria', 250, 'C');
INSERT INTO PRODS 
VALUES( 12, 'Impressora', 680,'P');
INSERT INTO PRODS 
VALUES( 13, 'Processador', 600, 'C');
INSERT INTO PRODS 
VALUES( 14, 'DVD-RW', 2, 'S');
INSERT INTO PRODS 
VALUES( 15, 'Papel A4', 19, 'S');
INSERT INTO PRODS 
VALUES( 16, 'Scanner', 199, 'P');


----------------- EXERCICIOS
-- 1

select count(*) as qtd
from prods;

-- 2

select count(distinct tipo)
from prods;

-- 3
select tipo, count(*) as qtd
from prods 
group by tipo;

-- 4

select avg(preco) as media
from prods;

--5
select avg(preco) as media
from prods
where tipo = 'S';


--6
select tipo, avg(preco) as media
from prods 
group by tipo;

ALTER TABLE PRODS ADD usuario numeric(1) NULL;

UPDATE PRODS
SET usuario = 1
WHERE codigo IN (10,12,13,14);

UPDATE PRODS
SET usuario = 2
WHERE usuario IS NULL;

SELECT tipo, usuario, AVG(preco)
FROM PRODS
GROUP BY tipo, usuario
ORDER BY tipo, usuario;

UPDATE PRODS
SET usuario = 2
WHERE codigo = 14;-- Deixando um produto sem usuario associado
UPDATE PRODS 
SET usuario = NULL
WHERE codigo = 13;

-- Executando novamente
SELECT tipo, usuario, AVG(preco)
FROM PRODS
GROUP BY tipo, usuario
ORDER BY tipo, usuario;

-----------------------------------------------
-- QUANTAS CIDADES EXISTEM EM CADA ESTADO?select C.uf, count(*) as qtdfrom cidades C group by C.uforder by qtd desc;-- RANKING DOS TELEFONES POR REGIÃOselect ddd, count(*) as qtdregiaofrom telefonesgroup by dddorder by qtdregiao;

-----------------------------------------------
-- Having

SELECT CID.nome, COUNT(*) as QTD
FROM CIDADES CID join ENDERECOS E
on CID.cod_cidade = E.cod_cidade
GROUP BY CID.nome
HAVING COUNT(*) > 1;


---------------------------------------------------

-- Criação das tabelas
CREATE TABLE TR
(
	 A numeric(2),
	 B numeric(2),
	 CONSTRAINT PK_TRA PRIMARY KEY(A)
);
CREATE TABLE TS
(
	 B numeric(2),
	 C numeric(2),
	 D numeric(2),
	 CONSTRAINT PK_TSB PRIMARY KEY(B)
);

INSERT INTO TR (A,B) VALUES (1,2);
INSERT INTO TR (A,B) VALUES (3,4);
INSERT INTO TS (B,C,D) VALUES (2,5,6);
INSERT INTO TS (B,C,D) VALUES (4,7,8);
INSERT INTO TS (B,C,D) VALUES (9,10,11);

-- Verificação dos conteúdos
SELECT * FROM TR;
SELECT * FROM TS;-- Acrescentar:
INSERT INTO TR (A,B) VALUES (9,NULL);
INSERT INTO TS (B,C,D) VALUES (15, NULL, NULL);
-- Depois remover:
DELETE FROM TR WHERE A=9;
DELETE FROM TS WHERE B=15;

-- Produto Cartesiano
SELECT * from TR,TS;
SELECT * from TR,TS WHERE TR.B IS NOT NULL;

-- Mais elaborado:
SELECT * FROM TR,TS WHERE TR.B = TS.B;

-- Junções
SELECT * from TR JOIN TS ON (TR.B = TS.B);
SELECT * from TR LEFT JOIN TS ON (TR.B = TS.B);
SELECT * from TR RIGHT JOIN TS ON (TR.B = TS.B);
SELECT * from TR FULL OUTER JOIN TS ON (TR.B = TS.B);

