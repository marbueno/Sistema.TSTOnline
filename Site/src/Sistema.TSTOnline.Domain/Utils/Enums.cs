using System.ComponentModel;

namespace Sistema.TSTOnline.Domain.Utils
{
    public enum OrdemServicoStatusEnum : int
    {
        [Description("INICIADO")]
        Iniciado = 1,

        [Description("EM ANDAMENTO")]
        EmAndamento = 2,

        [Description("PARCIALMENTE CONCLUÍDO")]
        ParcialmenteConcluido = 3,

        [Description("CONCLUÍDO")]
        Concluido = 4,

        [Description("CANCELADO")]
        Cancelado = 5
    }

    public enum PedidoVendaStatusEnum : int
    {
        [Description("ABERTO")]
        Aberto = 1,

        [Description("AGUARDANDO PAGAMENTO")]
        AguardandoPagamento = 2,

        [Description("FINALIZADO")]
        Finalizado = 3,

        [Description("CANCELADO")]
        Cancelado = 4
    }

    public enum OrigemMovimentoEstoqueEnum : int
    {
        [Description("MOVIMENTAÇÃO DE ESTOQUE")]
        MovimentacaoEstoque = 1,

        [Description("PEDIDO DE VENDA")]
        PedidoVenda = 2
    }

    public enum TipoMovimentoEstoqueEnum : int
    {
        [Description("ENTRADA")]
        Entrada = 1,

        [Description("SAÍDA")]
        Saida = 2
    }

    public enum OrigemContasReceberEnum : int
    {
        [Description("CONTAS A RECEBER")]
        ContasReceber = 1,

        [Description("PEDIDO DE VENDA")]
        PedidoVenda = 2
    }

    public enum ContasReceberStatusEnum : int
    {
        [Description("EM ABERTO")]
        EmAberto = 1,

        [Description("BAIXADO")]
        Baixado = 2,

        [Description("VENCIDO")]
        Vencido = 3,

        [Description("CANCELADO")]
        Cancelado = 4
    }

    public enum TipoLancamentoFluxoCaixaEnum : int
    {
        [Description("ENTRADA")]
        Entrada = 1,

        [Description("SAÍDA")]
        Saida = 2,
    }

    public enum OrigemFluxoCaixaEnum : int
    {
        [Description("FLUXO DE CAIXA")]
        FluxoCaixa = 1,

        [Description("CONTAS A RECEBER")]
        ContasReceber = 2
    }
}
