using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class OrdemServicoEN
    {
        [Key]
        public int IDOrdemServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataServico { get; set; }
        public int Status { get; set; }
        public int IDResp { get; set; }
        public int IDLocal { get; set; }

        private OrdemServicoEN()
        {
            DataCadastro = DateTime.Now;
            DataServico = DateTime.Now;
        }

        public OrdemServicoEN(DateTime DataServico, int Status, int IDResp, int IDLocal)
        {
            ValidateAndSetProperties(DataServico, Status, IDResp, IDLocal);
        }

        public void UpdateProperties(DateTime DataServico, int Status, int IDResp, int IDLocal)
        {
            ValidateAndSetProperties(DataServico, Status, IDResp, IDLocal);
        }

        private void ValidateAndSetProperties(DateTime DataServico, int Status, int IDResp, int IDLocal)
        {
            DomainException.When(DataServico == DateTime.MinValue, "Status não informado.");
            DomainException.When(Status == 0, "Status não informado.");
            DomainException.When(IDResp == 0, "Responsável pelo serviço não informado.");
            DomainException.When(IDLocal == 0, "Local do serviço não informado.");

            this.DataServico = DataServico;
            this.Status = Status;
            this.IDResp = IDResp;
            this.IDLocal = IDLocal;
        }
    }
}
