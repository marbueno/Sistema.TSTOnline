using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class FluxoCaixaEN
    {
        [Key]
        public int IDFluxoCaixa { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoLancamentoFluxoCaixaEnum TipoLancamento { get; set; }
        public OrigemFluxoCaixaEnum Origem { get; set; }
        public int Chave { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }

        public FluxoCaixaEN() { }

        public FluxoCaixaEN(DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            ValidateAndSetProperties(DataLancamento, TipoLancamento, Origem, Chave, Valor, Observacao);
        }

        public void UpdateProperties(DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            ValidateAndSetProperties(DataLancamento, TipoLancamento, Origem, Chave, Valor, Observacao);
        }

        private void ValidateAndSetProperties(DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            DomainException.When(DataLancamento == DateTime.MinValue, "Data de Lançamento Inválida.");
            DomainException.When(Valor == 0, "Valor não informado.");

            this.DataLancamento = DataLancamento;
            this.TipoLancamento = TipoLancamento;
            this.Origem = Origem;
            this.Chave = Chave;
            this.Valor = Valor;
            this.Observacao = Observacao;
        }
    }
}
