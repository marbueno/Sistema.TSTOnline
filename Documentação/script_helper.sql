select * from users where email like '%admin%' or email like '%nubia%'

select * from permission_groups;
select * from permission_params where name like '%categoria_view%';
select * from permission_params where name like '%servico_view%';

truncate table tbcadvendedor;
truncate table tbcadfornecedor;
select * from tbcadvendedor;
select * from tbcadfornecedor;
select * from tbCadServico;


select * from tbos;
select * from tbositem;

select * from tbpedidovenda;
select * from tbpedidovendaitem;

select * from tbProduto;
select * from tbMovimentoEstoque;
/* 
	truncate table tbos;
    truncate table tbositem;
	truncate table tbEstoque;
    truncate table tbProduto;
    truncate table tbpedidovenda;
    truncate table tbpedidovendaitem;
    truncate table tbMovimentoEstoque;
    truncate table tbContasReceber;
 */