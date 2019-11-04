select * from users where email like '%jomar%' or email like '%nubia%'

select * from permission_groups;
select * from permission_params where name like '%categoria_view%';

select * from permission_params where name like '%loca%';

select * from tbcadvendedor;
select * from tbcadfornecedor;
select * from tbCadServico;
select * From tbresponsavel;
select * From tbCadEmpresas where iduser = 5;

select * from tbos;
select * from tbositem;

select * from tbpedidovenda;
select * from tbpedidovendaitem;

select * from tbProduto;
select * from tbMovimentoEstoque;

select * from tbContasReceber;
select * from tbFluxoCaixa;

update tbcadvendedor set idcompany=1;
update tbcadfornecedor set idcompany=1;
update tbproduto set idcompany=1;
update tbprodutocategoria set idcompany=1;
update tbprodutosubcategoria set idcompany=1;
update tbpedidovenda set idcompany=1;
update tbos set idcompany=1;
update tbcadtiposervico set idcompany=1;
update tbcadlocalservico set idcompany=1;
update tbestoque set idcompany=1;
update tbmovimentoestoque set idcompany=1;
update tbcontasreceber set idcompany=1;
update tbfluxocaixa set idcompany=1;

ALTER TABLE `segurancast`.`tbcadvendedor` ADD COLUMN `idcompany` INT NULL AFTER `idvendedor`;
ALTER TABLE `segurancast`.`tbcadfornecedor` ADD COLUMN `idcompany` INT NULL AFTER `idfornecedor`;
ALTER TABLE `segurancast`.`tbproduto` ADD COLUMN `idcompany` INT NULL AFTER `idproduto`;
ALTER TABLE `segurancast`.`tbprodutocategoria` ADD COLUMN `idcompany` INT NULL AFTER `idcategoria`;
ALTER TABLE `segurancast`.`tbprodutosubcategoria` ADD COLUMN `idcompany` INT NULL AFTER `idsubcategoria`;
ALTER TABLE `segurancast`.`tbpedidovenda` ADD COLUMN `idcompany` INT NULL AFTER `idpedido`;
ALTER TABLE `segurancast`.`tbos` ADD COLUMN `idcompany` INT NULL AFTER `idordemservico`;
ALTER TABLE `segurancast`.`tbcadtiposervico` ADD COLUMN `idcompany` INT NULL AFTER `idtiposervico`;
ALTER TABLE `segurancast`.`tbcadlocalservico` ADD COLUMN `idcompany` INT NULL AFTER `idlocal`;
ALTER TABLE `segurancast`.`tbestoque` ADD COLUMN `idcompany` INT NULL AFTER `idproduto`;
ALTER TABLE `segurancast`.`tbmovimentoestoque` ADD COLUMN `idcompany` INT NULL AFTER `idmovimento`;
ALTER TABLE `segurancast`.`tbcontasreceber` ADD COLUMN `idcompany` INT NULL AFTER `idcontasreceber`;
ALTER TABLE `segurancast`.`tbfluxocaixa` ADD COLUMN `idcompany` INT NULL AFTER `idfluxocaixa`;

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
	truncate table tbcadvendedor;
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
