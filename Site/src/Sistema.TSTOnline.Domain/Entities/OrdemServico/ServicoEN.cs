using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class ServicoEN
    {
        [Key]
        public int IDServico { get; set; }
        public string Descricao { get; set; }

        private ServicoEN() { }

        public ServicoEN(string Descricao)
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
