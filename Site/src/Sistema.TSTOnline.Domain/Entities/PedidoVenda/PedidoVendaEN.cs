﻿using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.PedidoVenda
{
    public class PedidoVendaEN
    {
        [Key]
        public int IDPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVenda { get; set; }
        public PedidoVendaStatusEnum Status { get; set; }
        public int IDUsuario { get; set; }
        public int IDVendedor { get; set; }
        public int IDEmpresa { get; set; }
        public TipoPagamentoEnum TipoPagamento { get; set; }
        public QtdeParcelasEnum QtdeParcelas { get; set; }
        public string Observacao { get; set; }

        public PedidoVendaEN()
        {
            DataVenda = DateTime.Now;
        }

        public PedidoVendaEN(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor, int IDEmpresa, TipoPagamentoEnum TipoPagamento, QtdeParcelasEnum QtdeParcelas, string Observacao)
        {
            ValidateAndSetProperties(DataVenda, Status, IDUsuario, IDVendedor, IDEmpresa, TipoPagamento, QtdeParcelas, Observacao);
        }

        public void UpdateProperties(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor, int IDEmpresa, TipoPagamentoEnum TipoPagamento, QtdeParcelasEnum QtdeParcelas, string Observacao)
        {
            ValidateAndSetProperties(DataVenda, Status, IDUsuario, IDVendedor, IDEmpresa, TipoPagamento, QtdeParcelas, Observacao);
        }

        private void ValidateAndSetProperties(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor, int IDEmpresa, TipoPagamentoEnum TipoPagamento, QtdeParcelasEnum QtdeParcelas, string Observacao)
        {
            DomainException.When(DataVenda == DateTime.MinValue, "Data da Venda Inválida.");
            DomainException.When(Status == 0, "Status não informado.");
            DomainException.When(IDVendedor == 0, "Vendedor não informado.");
            DomainException.When(IDEmpresa == 0, "Cliente não informado.");
            DomainException.When(QtdeParcelas == 0, "Qtde de Parcelas Inválida.");

            this.DataVenda = DataVenda;
            this.Status = Status;
            this.IDUsuario = IDUsuario;
            this.IDVendedor = IDVendedor;
            this.IDEmpresa = IDEmpresa;
            this.TipoPagamento = TipoPagamento;
            this.QtdeParcelas = QtdeParcelas;
            this.Observacao = Observacao;
        }
    }
}
