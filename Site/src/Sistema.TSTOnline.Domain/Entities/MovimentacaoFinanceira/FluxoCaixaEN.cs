﻿using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class FluxoCaixaEN
    {
        [Key]
        public int IDFluxoCaixa { get; set; }
        public int IDUser { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoLancamentoFluxoCaixaEnum TipoLancamento { get; set; }
        public OrigemFluxoCaixaEnum Origem { get; set; }
        public int Chave { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }

        public FluxoCaixaEN() { }

        public FluxoCaixaEN(int IDUser, DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            ValidateAndSetProperties(IDUser, DataLancamento, TipoLancamento, Origem, Chave, Valor, Observacao);
        }

        public void UpdateProperties(int IDUser, DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            ValidateAndSetProperties(IDUser, DataLancamento, TipoLancamento, Origem, Chave, Valor, Observacao);
        }

        private void ValidateAndSetProperties(int IDUser, DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(DataLancamento == DateTime.MinValue, "Data de Lançamento Inválida.");
            DomainException.When(Valor == 0, "Valor não informado.");

            this.IDUser = IDUser;
            this.DataLancamento = DataLancamento;
            this.TipoLancamento = TipoLancamento;
            this.Origem = Origem;
            this.Chave = Chave;
            this.Valor = Valor;
            this.Observacao = Observacao;
        }
    }
}
