-- 5.1

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
-- cadastrados há menos de 4 meses.
select nome, t.numero
from usuarios u join clientes c on (u.cod_usuario = c.cod_cliente)
                join telefones t on (t.cod_cliente = c.cod_cliente)
where c.data_cadastro > sysdate-120;

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
select nome
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
                join estados using(uf)
                join pedidos p on (ce.cod_cliente = p.cod_cliente and
                                   ce.cod_endereco = p.cod_endereco)
                join pedidos_produtos pp using(num_pedido)
                join produtos pd using(cod_produto)
                join autores_produtos ap using(cod_produto)
                join autores au using(cod_autor)
where a.nivel_privilegio = 2 and 
      uf = 'PR' and
      au.nome = 'Paulo Coelho'
order by u.nome, c.data_cadastro desc;

--f. Listar o título dos produtos, o nome de seus autores 
-- (podendo ser em linhas separadas), seu preço e seu prazo 
-- de entrega, para todos os produtos importados.
select titulo, nome, preco, prazo_entrega
from produtos p join autores_produtos ap using(cod_produto)
                join autores au using(cod_autor)
where importado = 'S';                

--g. Listar o título dos produtos cujo autor eventualmente 
-- pode ser um cliente da loja, levando-se em consideração 
-- somente que possui o mesmo nome.
select titulo 
from produtos p join autores_produtos ap using(cod_produto)
                join autores a using(cod_autor)
where a.nome in (select nome 
                 from usuarios u join clientes c 
                      on(u.cod_usuario = c.cod_cliente));

--h. Listar, para cada ano desde 1998, o valor total 
-- comercializado dos produtos importados, somente 
-- para aqueles anos em que o número de produtos
-- importados vendidos foi maior que 1000 unidades.
select extract(year from p.data_emissao) ano, 
       sum(pp.quantidade*pp.valor_unitario)
from pedidos p join pedidos_produtos pp using(num_pedido)
               join produtos p using(cod_produto)
where extract(year from p.data_emissao) >= 1998 and
      p.importado = 'S'
group by extract(year from p.data_emissao)
having count(*) > 1000;

--i. Listar, sabendo que o prazo de entrega é de 3 meses, 
-- o nome dos produtos e o prazo de entrega do último pedido 
-- dos clientes cujo nome inicia com 'Paulo'.
select titulo, p.data_emissao + 90 prazo_entrega
from pedidos p join pedidos_produtos pp using(num_pedido)
               join produtos using(cod_produto)
               join clientes_enderecos ce on (p.cod_cliente = ce.cod_cliente and
                                              p.cod_endereco = ce.cod_endereco)
               join clientes c on (ce.cod_cliente = c.cod_cliente)
               join usuarios u on(c.cod_cliente = u.cod_usuario)
where u.nome like 'Paulo%' and
      num_pedido = (select max(num_pedido)
                      from pedidos p1 join clientes_enderecos ce1 on (p1.cod_cliente = ce1.cod_cliente and
                                                                      p1.cod_endereco = ce1.cod_endereco)
                                      join clientes c1 on (ce1.cod_cliente = c1.cod_cliente)
                                      join usuarios u1 on(c1.cod_cliente = u1.cod_usuario)
                      where c1.cod_cliente = c.cod_cliente);

--j. Listar o título dos produtos que possuam total vendido 
-- superior ao total vendido no mês de novembro de 2002 por 
-- todos os produtos importados que tenham sido incluídos 
-- em mais de 10 pedidos.

select titulo, sum(pp0.quantidade*pp0.valor_unitario)
from produtos p0 join pedidos_produtos pp0 using(cod_produto)
group by titulo
having sum(pp0.quantidade*pp0.valor_unitario) > (
  select sum(pp.quantidade*pp.valor_unitario)
  from pedidos_produtos pp join pedidos p using(num_pedido)
                           join produtos prd using(cod_produto)
  where p.data_emissao >= to_date('01/11/2002','dd/mm/yyyy') and
        p.data_emissao <= to_date('30/11/2002','dd/mm/yyyy') and
        prd.importado = 'S' and
        cod_produto in (select cod_produto
                            from produtos prd1 join pedidos_produtos pp1 using(cod_produto)
                            group by cod_produto
                            having count(distinct num_pedido) > 10)
);



-- 5.2 Exercícios de INSERT, UPDATE e DELETE com subconsultas.

-- a. Insira na tabela PESSOAS os clientes do estado do Rio Grande do Sul (utilize as tabelas do Estudo de Caso).

insert into pessoas
   select usuarios.cpf, usuarios.nome, trunc((months_between(sysdate,data_nascimento))/12), enderecos.rua || ' ' || to_char(enderecos.numero)
   from usuarios 
        join clientes
          on usuarios.cod_usuario = clientes.cod_cliente
        join clientes_enderecos using (cod_cliente)
        join enderecos using (cod_endereco)
        join cidades using (cod_cidade)
        join estados using (uf)
   where estados.uf = ‘RS’;

-- b. Adicione um asterisco no final dos nomes da tabela PESSOAS para os clientes que não tenham indicado DDD em um de seus telefones. Lembre-se de que o operador de concatenação é ||.

update pessoas
set pessoas.nome = pessoas.nome || ' *'
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

delete from pessoas
where cpf in 
(
   select usuarios.cpf
      from usuarios 
         join clientes
               onusuarios.cod_usuario = clientes.cod_cliente
         join clientes_enderecos using (cod_cliente)
         join enderecos using (cod_endereco)
         join cidades using (cod_cidade)
         join estados using (uf)
   where estados.uf = 'RS' and cidades.nome <> 'Piratini'
); 




