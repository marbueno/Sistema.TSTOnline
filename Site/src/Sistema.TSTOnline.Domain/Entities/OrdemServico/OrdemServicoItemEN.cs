using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class OrdemServicoItemEN
    {
        [Key]
        public int IDOrdemServicoItem { get; set; }
        public int IDCompany { get; set; }
        public int IDOrdemServico { get; set; }
        public int Item { get; set; }
        public int IDTipoServico { get; set; }
        public string Observacao { get; set; }
        public bool Concluido { get; set; }

        private OrdemServicoItemEN() { }

        public OrdemServicoItemEN(int IDOrdemServico, int Item, int IDTipoServico, string Observacao, bool Concluido)
        {
            ValidateAndSetProperties(IDOrdemServico, Item, IDTipoServico, Observacao, Concluido);
        }

        public void UpdateProperties(int IDOrdemServico, int Item, int IDTipoServico, string Observacao, bool Concluido)
        {
            ValidateAndSetProperties(IDOrdemServico, Item, IDTipoServico, Observacao, Concluido);
        }

        private void ValidateAndSetProperties(int IDOrdemServico, int Item, int IDTipoServico, string Observacao, bool Concluido)
        {
            DomainException.When(IDOrdemServico == 0, "Código da Ordem de Serviço não informada.");
            DomainException.When(Item == 0, "Número do Item não informado.");
            DomainException.When(IDTipoServico == 0, "Tipo de Serviço não informado.");

            this.IDOrdemServico = IDOrdemServico;
            this.Item = Item;
            this.IDTipoServico = IDTipoServico;
            this.Observacao = Observacao;
            this.Concluido = Concluido;
        }
    }
}
