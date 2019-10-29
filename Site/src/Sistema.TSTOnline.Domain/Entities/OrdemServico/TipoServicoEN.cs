using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class TipoServicoEN
    {
        [Key]
        public int IDTipoServico { get; set; }
        public int IDUser { get; set; }
        public string Descricao { get; set; }

        private TipoServicoEN() { }

        public TipoServicoEN(int IDUser, string Descricao)
        {
            ValidateAndSetProperties(IDUser, Descricao);
        }

        public void UpdateProperties(int IDUser, string Descricao)
        {
            ValidateAndSetProperties(IDUser, Descricao);
        }

        private void ValidateAndSetProperties(int IDUser, string Descricao)
        {
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");

            this.IDUser = IDUser;
            this.Descricao = Descricao;
        }
    }
}
