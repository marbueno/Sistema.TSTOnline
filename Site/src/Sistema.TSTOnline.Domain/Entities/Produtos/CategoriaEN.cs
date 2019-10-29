using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Produtos
{
    public class CategoriaEN
    {
        [Key]
        public int IDCategoria { get; set; }
        public int IDUser { get; set; }
        public string Descricao { get; set; }

        private CategoriaEN() { }

        public CategoriaEN(int IDUser, string Descricao)
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
