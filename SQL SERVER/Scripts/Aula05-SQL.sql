-- Usando HAVING-- QUANTAS CIDADES EXISTEM EM CADA ESTADO?select C.uf, count(*) as qtdfrom cidades C group by C.ufhaving count(*) > 200order by qtd desc;-- RANKING DOS TELEFONES POR REGIÃOselect ddd, count(*) as qtdregiaofrom telefonesgroup by dddorder by qtdregiao;select tipo, avg(preco) as mediafrom prodsgroup by tipohaving avg(preco) < 400;-------------------------------------------------- EXERCICIOSCREATE TABLE Funcionarios (
  Cod numeric(2) PRIMARY KEY,
  Nome Varchar(30) NOT NULL,
  Sexo Char(1),
  Depto Varchar(15),
  Salario numeric(10,2)
)

INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (10,'Joao'  ,'M','Compras'  ,1000.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (12,'Maria'  ,'F','Vendas'  , 970.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (35,'Pedro'  ,'M','Expedicao', 800.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (08,'Ana'    ,'F','Expedicao', 790.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (37,'Carlos' ,'M','Vendas'  ,2090.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (47,'Marco'  ,'M','Compras'  ,1970.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (18,'Tiago'  ,'M','Expedicao', 700.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (32,'Lucas'  ,'M','Vendas'  ,4820.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (09,'Claudia','F','Vendas'  ,2220.00);
INSERT INTO Funcionarios (Cod, Nome, Sexo, Depto, Salario) VALUES (15,'Joana'  ,'F','Compras'  , 770.00);


-- QUESTAO A. Escreva os SELECTs --

-- 1. Quantidade de Funcionários por Departamento

select depto, count(*) as qtd
from Funcionarios
group by depto;

-- 2. Que departamentos tem média salarial maior que R$ 1000?

select depto, avg(Salario) as mediasalarial
from Funcionarios
group by depto
having avg(Salario) > 1000;

-- 3. Média salárial dos funcionários por sexo do setor de Compras

select depto, Sexo, avg(Salario) as mediasalarial
from Funcionarios
where Depto = 'Compras'
group by Sexo;

-- 4. O maior salário do departamento que possui pelo menos duas pessoas

select depto, MAX(salario) 
from Funcionarios
group by depto
having count(Nome) > 2;

-- 5. Número de pessoas por sexo, por departamento

select depto, sexo, count(sexo) as qtdporsexo
from funcionarios 
group by depto, Sexo
order by depto, sexo;

-- 6. Qual o total da folha de pagamento de cada departamento?

select depto, sum(salario) as totalfolhadepagamento 
from funcionarios
group by depto;

-- 7. Soma dos salários dos Departamentos com mais de 1 funcionário

select depto, sum(salario) as totalfolhadepagamento 
from funcionarios
group by depto
having count(*) > 3;

-- QUESTAO B. Modifique o Esquema --
-- 1. Exporte a coluna de departamento para outra tabela (crie codigo e descrição).
-- 2. Refaça as consultas anteriores usando joins quando for necessário
-- 3. Crie uma nova tabela (à sua escolha) e crie pelo menos 3 SELECTs que contenham funções de agregação e/ou group by.

-- Registre suas respostas no fórum.

select * from Funcionarios;

----------------------------------------------------------
-- SUB CONSULTA
----------------------------------------------------------

SELECT preco
FROM PRODUTOS
WHERE cod_produto = 142;

SELECT titulo, PRECO
FROM PRODUTOS
WHERE preco > 
 (SELECT preco
 FROM PRODUTOS
 WHERE cod_produto = 142) ORDER BY preco asc; SELECT titulo
FROM PRODUTOS
WHERE importado = 'N' AND preco > 
 (SELECT MAX(preco)
 FROM PRODUTOS
 WHERE importado = 'S');

SELECT ano_lancamento, AVG(preco) as mediadepreco
FROM PRODUTOS
GROUP BY ano_lancamento
HAVING AVG(preco) > 
 (SELECT AVG(preco)
 FROM PRODUTOS
 WHERE ano_lancamento = DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)); ------------------------------------------------------------ -- OPERADOR IN SELECT PED.num_pedido
FROM pedidos PED
WHERE ped.cod_cliente IN
 (SELECT ADM.cod_administrador
 FROM administradores ADM);


SELECT PED.num_pedido
FROM pedidos PED
WHERE PED.cod_endereco in
 (SELECT E.cod_cidade, E.cod_endereco
 FROM enderecos E
 WHERE E.cod_cidade = 20);

 ----------------------------------------
 -- OPERADOR ANY E SOME

 SELECT PROD.titulo
FROM produtos PROD
WHERE PROD.importado = 'N' AND PROD.preco > ANY 
 (SELECT PROD1.preco
 FROM produtos PROD1
 WHERE PROD1.importado = 'S');

 --------------------------------------------------
 -- OPERADOR ALL

 SELECT PROD.titulo
FROM produtos PROD
WHERE PROD.importado = 'N' AND PROD.preco > ALL 
 (SELECT PROD1.preco
 FROM produtos PROD1
 WHERE PROD1.importado = 'S');

  --------------------------------------------------
 -- OPERADOR EXISTS

 SELECT USU.Nome
FROM Usuarios USU, Administradores ADM
WHERE USU.cod_usuario = ADM.cod_administrador AND
 ADM.nivel_privilegio > 2 AND EXISTS
 (SELECT * 
 FROM Pedidos PED
 WHERE PED.Cod_Cliente = ADM.cod_administrador)

--------------------------------------------------------
-- Exemplo com INSERT

INSERT INTO PRODS(codigo, nome, preco, tipo, usuario)
 SELECT P.cod_produto
 SUBSTR(titulo, 1, 15), 
 preco, 'L' -- coluna constante para todos os registros
 FROM produtos P
 WHERE 
 importado = 'N'
 AND titulo LIKE 'A%'
 AND cod_produto > 100;

---------------------------------------------------------------
-- Exemplo com UPDATE

UPDATE PRODUTOS
SET preco = preco - (10/100 * preco)
WHERE cod_produto IN
(
 SELECT cod_produto
 FROM PRODUTOS
 WHERE prazo_entrega > 30
);

------------------------------------------------------------------
-- Exemplo com DELETE

DELETE FROM PRODS
WHERE codigo IN
(
 SELECT cod_produto
 FROM PRODUTOS
 WHERE
 importado = 'N'
 AND titulo LIKE 'A%'
 AND cod_produto > 100
);


