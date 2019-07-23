using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.OrdemServico
{
    public class OrdemServicoItemEN
    {
        [Key]
        public int IDOrdemServicoItem { get; set; }
        public int IDOrdemServico { get; set; }
        public int Item { get; set; }
        public int IDServico { get; set; }

        private OrdemServicoItemEN() { }

        public OrdemServicoItemEN(int IDOrdemServico, int Item, int IDServico)
        {
            ValidateAndSetProperties(IDOrdemServico, Item, IDServico);
        }

        public void UpdateProperties(int IDOrdemServico, int Item, int IDServico)
        {
            ValidateAndSetProperties(IDOrdemServico, Item, IDServico);
        }

        private void ValidateAndSetProperties(int IDOrdemServico, int Item, int IDServico)
        {
            DomainException.When(IDOrdemServico == 0, "Código da Ordem de Serviço não informada.");
            DomainException.When(Item == 0, "Número do Item não informado.");
            DomainException.When(IDServico == 0, "Serviço não informado.");

            this.IDOrdemServico = IDOrdemServico;
            this.Item = Item;
            this.IDServico = IDServico;
        }
    }
}
