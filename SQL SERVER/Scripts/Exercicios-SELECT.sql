
--a. Listar o nome, o endereço (rua, número e complemento) 
-- e o número dos pedidos dos clientes.
select nome, e.rua, e.numero, e.complemento, p.num_pedido
from usuarios u 
     join clientes c on (u.cod_usuario = c.cod_cliente)
     join clientes_enderecos ce on (c.cod_cliente = ce.cod_cliente)
     join enderecos e on (e.cod_endereco = ce.cod_endereco)
     join pedidos p on (ce.cod_cliente = p.cod_cliente and 
                        ce.cod_endereco = p.cod_endereco);

--b. Listar o nome e os telefones de todos os clientes 
-- cadastrados há menos de 350 meses.
select nome, t.numero
from usuarios u join clientes c on (u.cod_usuario = c.cod_cliente)
                join telefones t on (t.cod_cliente = c.cod_cliente)
where c.data_cadastro > DATEADD(month, -350, GETDATE());

--c. Listar o nome das cidades do estado do Tocantins 
-- que possuam algum endereço cadastrado.
select distinct c.nome
from estados e join cidades c on c.uf = e.uf
               join enderecos en on en.cod_cidade = c.cod_cidade
where e.uf = 'TO';

--d. Listar o nome dos usuários que são clientes e 
-- administradores, em ordem crescente de data de 
-- cadastro (quem não possui data de cadastro deve ser
--posicionado no final).
select nome, c.data_cadastro
from usuarios u join clientes c on (u.cod_usuario = c.cod_cliente)
                join administradores a on (u.cod_usuario = a.cod_administrador)
order by c.data_cadastro;

--e. Listar (uma única vez) o nome de cada administrador 
-- de nível 2 que reside no Paraná e adquiriu produto do 
-- autor 'Paulo Coelho' em ordem de nome e inversa de data 
-- de cadastro.
select distinct u.nome, c.data_cadastro
from usuarios u join clientes c on (u.cod_usuario = c.cod_cliente)
                join administradores a on (u.cod_usuario = a.cod_administrador)
                join clientes_enderecos ce on (c.cod_cliente = ce.cod_cliente)
                join enderecos e on(e.cod_endereco = ce.cod_endereco)
                join cidades cd on (e.cod_cidade = cd.cod_cidade)
                join estados et on cd.uf = et.uf
				join pedidos p on (ce.cod_cliente = p.cod_cliente and
                                   ce.cod_endereco = p.cod_endereco)
                join pedidos_produtos pp on pp.num_pedido = p.num_pedido
                join produtos pd on pd.cod_produto = pp.cod_produto
                join autores_produtos ap on ap.cod_produto= pd.cod_produto
                join autores au on au.cod_autor = ap.cod_autor
where a.nivel_privilegio = 2 and 
      et.uf = 'PR' and
      au.nome = 'Paulo Coelho'
order by u.nome, c.data_cadastro desc;

--f. Listar o título dos produtos, o nome de seus autores 
-- (podendo ser em linhas separadas), seu preço e seu prazo 
-- de entrega, para todos os produtos importados.
select p.titulo, au.nome, p.preco, p.prazo_entrega
from produtos p join autores_produtos ap on ap.cod_produto = p.cod_produto
                join autores au on au.cod_autor = ap.cod_autor
where importado = 'S';                

--g. Listar o título dos produtos cujo autor eventualmente 
-- pode ser um cliente da loja, levando-se em consideração 
-- somente que possui o mesmo nome.
select p.titulo, a.nome 
from produtos p join autores_produtos ap on ap.cod_produto = p.cod_produto
                join autores a on a.cod_autor = ap.cod_autor
where a.nome in (select u.nome 
                 from usuarios u join clientes c 
                      on(u.cod_usuario = c.cod_cliente));

select u.nome, a.cod_autor, u.cod_usuario
from usuarios u join clientes c on (u.cod_usuario = c.cod_cliente)
join autores a on a.cod_autor = u.cod_usuario
where u.nome like '%Adauto Pereira%' or u.nome like '%Sonnia Gu Sy Fiori%';

--h. Listar, para cada ano desde 1998, o valor total 
-- comercializado dos produtos importados, somente 
-- para aqueles anos em que o número de produtos
-- importados vendidos foi maior que 1000 unidades.
select year(p.data_emissao) ano, 
       sum(pp.quantidade*pp.valor_unitario) as valortotal
from pedidos p join pedidos_produtos pp on p.num_pedido = pp.num_pedido
               join produtos pd on pd.cod_produto = pp.cod_produto
where year(p.data_emissao) >= 1998 and
      pd.importado = 'S'
group by year(p.data_emissao)
having count(*) > 1000;

--i. Listar, sabendo que o prazo de entrega é de 8 dias, 
-- o nome dos produtos e o prazo de entrega do último pedido 
-- dos clientes cujo nome inicia com 'Adelina Alcântara'.
select pd.titulo, pd.prazo_entrega
from pedidos p join pedidos_produtos pp on pp.num_pedido = p.num_pedido
               join produtos pd on pd.cod_produto = pp.cod_produto
               join clientes_enderecos ce on (p.cod_cliente = ce.cod_cliente and
                                              p.cod_endereco = ce.cod_endereco)
               join clientes c on (ce.cod_cliente = c.cod_cliente)
               join usuarios u on(c.cod_cliente = u.cod_usuario)
where u.nome like '%Adelina Alcântara%' and pd.prazo_entrega = 8 and
      p.num_pedido = (select max(num_pedido)
                      from pedidos p1 join clientes_enderecos ce1 on (p1.cod_cliente = ce1.cod_cliente and
                                                                      p1.cod_endereco = ce1.cod_endereco)
                                      join clientes c1 on (ce1.cod_cliente = c1.cod_cliente)
                                      join usuarios u1 on(c1.cod_cliente = u1.cod_usuario)
                      where c1.cod_cliente = c.cod_cliente);

--j. Listar o título dos produtos que possuam total vendido 
-- superior ao total vendido no mês de novembro de 2002 por 
-- todos os produtos importados que tenham sido incluídos 
-- em mais de 10 pedidos.

select titulo, sum(pp0.quantidade*pp0.valor_unitario) as totalvendido
from produtos p0 join pedidos_produtos pp0 on pp0.cod_produto = p0.cod_produto
group by titulo
having sum(pp0.quantidade*pp0.valor_unitario) > (
  select sum(pp.quantidade*pp.valor_unitario)
  from pedidos_produtos pp join pedidos p on pp.num_pedido = p.num_pedido
                           join produtos prd on prd.cod_produto = pp.cod_produto
WHERE p.data_emissao >= '2002-11-01' and
		p.data_emissao <= '2002-11-30' and
        prd.importado = 'S' and
        prd.cod_produto in (select prd1.cod_produto
                            from produtos prd1 join pedidos_produtos pp1 on prd1.cod_produto = pp1.cod_produto
                            group by prd1.cod_produto
                            having count(distinct num_pedido) > 10)
);


-- 5.2 Exercícios de INSERT, UPDATE e DELETE com subconsultas.

CREATE TABLE PESSOAS
(
cpf VARCHAR(20) NOT NULL,
 nome VARCHAR(150) NOT NULL,
 idade numeric(3) NULL,
endereco VARCHAR(150) NULL
);

-- a. Insira na tabela PESSOAS os clientes do estado do Rio Grande do Sul (utilize as tabelas do Estudo de Caso).

INSERT INTO pessoas (cpf, nome, idade, endereco)
SELECT 
    usuarios.cpf, 
    usuarios.nome, 
    FLOOR(DATEDIFF(month, clientes.data_nascimento, GETDATE()) / 12.0) AS idade, 
    enderecos.rua + ' ' + CAST(enderecos.numero AS VARCHAR) AS endereco_completo
FROM 
    usuarios 
    JOIN clientes ON usuarios.cod_usuario = clientes.cod_cliente
    JOIN clientes_enderecos ON clientes_enderecos.cod_cliente = clientes.cod_cliente
    JOIN enderecos ON enderecos.cod_endereco = clientes_enderecos.cod_endereco
    JOIN cidades ON cidades.cod_cidade = enderecos.cod_cidade
    JOIN estados ON estados.uf = cidades.uf
WHERE 
    estados.uf = 'RS';

	select * from pessoas;

-- b. Adicione um asterisco no final dos nomes da tabela PESSOAS para os clientes que não tenham indicado DDD em um de seus telefones. Lembre-se de que o operador de concatenação é ||.

update pessoas
set pessoas.nome = pessoas.nome + ' *'
where cpf in 
( select  usuarios.cpf
  from usuarios 
       join clientes 
            on usuarios.cod_usuario = clientes.cod_cliente
       join telefones 
            on clientes.cod_cliente = telefones.cod_cliente
  where telefones.ddd is null
);


-- c. Exclua da tabela PESSOAS os clientes que não morem na cidade de Piratini.

DELETE FROM pessoas
WHERE cpf IN (
    SELECT usuarios.cpf
    FROM usuarios 
    JOIN clientes ON usuarios.cod_usuario = clientes.cod_cliente
    JOIN clientes_enderecos ON clientes_enderecos.cod_cliente = clientes.cod_cliente
    JOIN enderecos ON enderecos.cod_endereco = clientes_enderecos.cod_endereco
    JOIN cidades ON cidades.cod_cidade = enderecos.cod_cidade
    JOIN estados ON estados.uf = cidades.uf
    WHERE estados.uf = 'RS' AND cidades.nome <> 'Piratini'
);

