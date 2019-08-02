using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class TipoServicoEN
    {
        [Key]
        public int IDTipoServico { get; set; }
        public string Descricao { get; set; }

        private TipoServicoEN() { }

        public TipoServicoEN(string Descricao)
        {
            ValidateAndSetProperties(Descricao);
        }

        public void UpdateProperties(string Descricao)
        {
            ValidateAndSetProperties(Descricao);
        }

        private void ValidateAndSetProperties(string Descricao)
        {
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");

            this.Descricao = Descricao;
        }
    }
}
