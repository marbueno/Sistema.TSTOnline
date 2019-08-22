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
}
