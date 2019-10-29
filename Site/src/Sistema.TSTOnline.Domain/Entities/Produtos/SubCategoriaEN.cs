using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Produtos
{
    public class SubCategoriaEN
    {
        [Key]
        public int IDSubCategoria { get; set; }
        public int IDUser { get; set; }
        public int IDCategoria { get; set; }
        public string Descricao { get; set; }

        private SubCategoriaEN() { }

        public SubCategoriaEN(int IDUser, int IDCategoria, string Descricao)
        {
            ValidateAndSetProperties(IDUser, IDCategoria, Descricao);
        }

        public void UpdateProperties(int IDUser, int IDCategoria, string Descricao)
        {
            ValidateAndSetProperties(IDUser, IDCategoria, Descricao);
        }

        private void ValidateAndSetProperties(int IDUser, int IDCategoria, string Descricao)
        {
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(IDCategoria == 0, "Categoria não informada.");
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");

            this.IDUser = IDUser;
            this.IDCategoria = IDCategoria;
            this.Descricao = Descricao;
        }
    }
}
