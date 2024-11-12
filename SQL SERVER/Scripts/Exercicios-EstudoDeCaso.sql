---------------------------------------
-- Exercicios sobre o Estudo de Caso
---------------------------------------

-- EC1. Qual a quantidade de endereços por estado?

select estados.uf, count(*) as qtdEnderecos
from estados join cidades on cidades.uf = estados.uf
             join enderecos on enderecos.cod_cidade = cidades.cod_cidade
group by estados.uf;

-- EC2. Qual a quantidade de clientes de cada estado?

select estados.uf, count(distinct cod_cliente)
from estados join cidades on cidades.uf = estados.uf
             join enderecos on cidades.cod_cidade = enderecos.cod_cidade 
             join clientes_enderecos on clientes_enderecos.cod_endereco = enderecos.cod_endereco
group by estados.uf;

-- EC3. Qual o ranking de estados por quantidade de clientes, ou seja, em ordem decrescente de quantidade de clientes?

select estados.uf, count(distinct cod_cliente) as ranking
from estados join cidades on cidades.uf = estados.uf
             join enderecos on enderecos.cod_cidade = cidades.cod_cidade
             join clientes_enderecos on clientes_enderecos.cod_endereco = enderecos.cod_endereco
group by estados.uf
order by count(distinct cod_cliente) desc;

-- EC4. Qual o ranking de regiões por quantidade de clientes, ou seja, em ordem decrescente de quantidade de clientes?

select estados.regiao, count(distinct cod_cliente) as qtdClientes
from estados join cidades on estados.uf = cidades.uf
			 join enderecos on enderecos.cod_cidade = cidades.cod_cidade
             join clientes_enderecos on clientes_enderecos.cod_endereco = enderecos.cod_endereco
group by estados.regiao
order by count(distinct cod_cliente) desc;

-- EC5. Qual a quantidade de pedidos por região?

select estados.regiao, count(*) as qtdPedidos
from estados join cidades on estados.uf = cidades.uf
              join enderecos on enderecos.cod_cidade = cidades.cod_cidade
             join clientes_enderecos on clientes_enderecos.cod_endereco = enderecos.cod_endereco
             join pedidos on pedidos.cod_endereco = clientes_enderecos.cod_endereco
group by estados.regiao;


-- EC6. Qual a quantidade de pedidos por ano e por região, considerando apenas os pedidos feitos nos anos de 2000 até 2004?


SELECT YEAR(data_emissao) AS Ano, regiao, COUNT(*) AS qtdPedidos
FROM estados 
		JOIN cidades ON estados.uf = cidades.uf
		JOIN enderecos ON enderecos.cod_cidade = cidades.cod_cidade
		JOIN clientes_enderecos ON clientes_enderecos.cod_endereco = enderecos.cod_endereco
		JOIN pedidos ON pedidos.cod_endereco = clientes_enderecos.cod_endereco
		WHERE YEAR(data_emissao) BETWEEN 2000 AND 2004
GROUP BY YEAR(data_emissao), regiao
ORDER BY YEAR(data_emissao), regiao;

-- EC7. Qual o valor total gasto por cliente, ordenado em ordem decrescente de valor total?

select clientes.cod_cliente, sum(quantidade * valor_unitario) AS valortotal
from clientes join clientes_enderecos on clientes.cod_cliente = clientes_enderecos.cod_cliente
              join pedidos on pedidos.cod_endereco = clientes_enderecos.cod_endereco
              join pedidos_produtos on pedidos_produtos.num_pedido = pedidos.num_pedido
group by clientes.cod_cliente
order by sum(quantidade * valor_unitario) desc;

-- EC8. Qual o valor total gasto por cliente, ordenado em ordem decrescente de valor total, considerando apenas os clientes do Rio Grande do Sul?

select clientes.cod_cliente, sum(quantidade * valor_unitario) as valortotal
from clientes join clientes_enderecos on clientes.cod_cliente = clientes_enderecos.cod_cliente
              join pedidos on pedidos.cod_endereco = clientes_enderecos.cod_endereco
			  join pedidos_produtos on pedidos_produtos.num_pedido = pedidos.num_pedido
              join enderecos on enderecos.cod_endereco = clientes_enderecos.cod_endereco
              join cidades on cidades.cod_cidade = enderecos.cod_cidade
              join estados on cidades.uf = estados.uf
where estados.uf = 'RS'
group by clientes.cod_cliente
order by valortotal desc;

-- EC9. Qual o valor total vendido por autor?

select a.nome, sum(quantidade * valor_unitario) as valortotal
from autores A join autores_produtos AP on AP.cod_autor = A.cod_autor
             join produtos P ON P.cod_produto = AP.cod_produto
             join pedidos_produtos PP ON PP.cod_produto = P.cod_produto
group by a.nome
ORDER BY A.nome;

-- EC10. Qual o valor médio faturado com as vendas por produto?

select P.cod_produto, avg(quantidade * valor_unitario) as valormedio
from produtos P join pedidos_produtos PP on P.cod_produto = PP.cod_produto
group by P.cod_produto;

-- EC11. Qual o valor total de cada pedido?

select P.num_pedido, sum(quantidade * valor_unitario) as valortotal
from pedidos P join pedidos_produtos PP ON P.num_pedido = PP.num_pedido
group by P.num_pedido;

-- EC12. Qual o valor médio dos pedidos por estado?

select ET.uf, sum(quantidade * valor_unitario) / count(distinct P.num_pedido) AS valormedio
from pedidos P join pedidos_produtos PP ON P.num_pedido = PP.num_pedido
             join clientes_enderecos CE ON P.cod_endereco = CE.cod_endereco
             join enderecos E ON E.cod_endereco = CE.cod_endereco
             join cidades C ON C.cod_cidade = E.cod_cidade
             join estados ET ON ET.uf = C.uf
group by ET.uf;
