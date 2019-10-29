select * from users where email like '%admin%' or email like '%nubia%'

select * from permission_groups;
select * from permission_params where name like '%categoria_view%';

select * from permission_params where name like '%loca%';

truncate table tbcadvendedor;
truncate table tbcadfornecedor;
select * from tbcadvendedor;
select * from tbcadfornecedor;
select * from tbCadServico;
select * From tbresponsavel;
select * From tbCadEmpresas;

select * from tbos;
select * from tbositem;

select * from tbpedidovenda;
select * from tbpedidovendaitem;

select * from tbProduto;
select * from tbMovimentoEstoque;

select * from tbContasReceber;
select * from tbFluxoCaixa;

update tbContasReceber set status = 1 where idcontasreceber = 3
/* 
	truncate table tbos;
    truncate table tbositem;
	truncate table tbEstoque;
    truncate table tbProduto;
    truncate table tbpedidovenda;
    truncate table tbpedidovendaitem;
    truncate table tbMovimentoEstoque;
    truncate table tbContasReceber;
    truncate table tbcadfornecedor;
 */
 
 update tbcadvendedor set iduser=1;
update tbcadfornecedor set iduser=1;
update tbproduto set iduser=1;
update tbprodutocategoria set iduser=1;
update tbprodutosubcategoria set iduser=1;
update tbpedidovenda set iduser=1;
update tbos set iduser=1;
update tbcadtiposervico set iduser=1;
update tbcadlocalservico set iduser=1;
update tbestoque set iduser=1;
update tbmovimentoestoque set iduser=1;
update tbcontasreceber set iduser=1;
update tbfluxocaixa set iduser=1;
 
 
 
 CREATE TABLE `tbcadvendedor` (
  `idvendedor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) DEFAULT NULL,
  `rg` varchar(12) DEFAULT NULL,
  `cpf` varchar(14) DEFAULT NULL,
  `dataNascimento` date DEFAULT NULL,
  `cep` varchar(9) DEFAULT NULL,
  `endereco` varchar(200) DEFAULT NULL,
  `numero` varchar(10) DEFAULT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  `bairro` varchar(80) DEFAULT NULL,
  `cidade` varchar(50) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `nomecontato` varchar(45) DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `whatsapp` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`idvendedor`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
