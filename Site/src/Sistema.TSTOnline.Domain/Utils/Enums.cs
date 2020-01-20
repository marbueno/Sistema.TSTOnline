using System.ComponentModel;

namespace Sistema.TSTOnline.Domain.Utils
{
    public enum OrdemServicoStatusEnum : int
    {
        [Description("TODOS OS STATUS")]
        Todos = 0,

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
        [Description("TODOS OS STATUS")]
        Todos = 0,

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
        [Description("TODOS OS STATUS")]
        Todos = 0,

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

    public enum TipoPagamentoEnum : int
    {
        [Description("BOLETO")]
        Boleto = 1,

        [Description("CARTÃO DE CRÉDITO")]
        CartaoCredito = 2,

        [Description("CARTÃO DE DÉBITO")]
        CartaoDebito = 3,

        [Description("DINHEIRO")]
        Dinheiro = 4,

        [Description("LOJA ONLINE")]
        LojaOnline = 5,

        [Description("TRANSFERÊNCIA")]
        Transferencia = 6,
    }

    public enum QtdeParcelasEnum : int
    {
        [Description("À VISTA")]
        AVista = 1,

        [Description("2x")]
        DuasVezes = 2,

        [Description("3x")]
        TresVezes = 3,

        [Description("4x")]
        QuatroVezes = 4,

        [Description("5x")]
        CincoVezes = 5,

        [Description("6x")]
        SeisVezes = 6,

        [Description("7x")]
        SeteVezes = 7,

        [Description("8x")]
        OitoVezes = 8,

        [Description("9x")]
        NoveVezes = 9,

        [Description("10x")]
        DezVezes = 10,

        [Description("11x")]
        OnzeVezes = 11,

        [Description("12x")]
        DozeVezes = 12,
    }

    public enum TipoPessoa : int
    {
        [Description("FÍSICA")]
        Fisica = 1,

        [Description("JURÍDICA")]
        Juridica = 2
    }
}
