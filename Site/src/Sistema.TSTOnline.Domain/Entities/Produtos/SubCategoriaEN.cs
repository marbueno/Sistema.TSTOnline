using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Produtos
{
    public class SubCategoriaEN
    {
        [Key]
        public int IDSubCategoria { get; set; }
        public int IDCategoria { get; set; }
        public string Descricao { get; set; }

        private SubCategoriaEN() { }

        public SubCategoriaEN(int IDCategoria, string Descricao)
        {
            ValidateAndSetProperties(IDCategoria, Descricao);
        }

        public void UpdateProperties(int IDCategoria, string Descricao)
        {
            ValidateAndSetProperties(IDCategoria, Descricao);
        }

        private void ValidateAndSetProperties(int IDCategoria, string Descricao)
        {
            DomainException.When(IDCategoria == 0, "Categoria não informada.");
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");

            this.IDCategoria = IDCategoria;
            this.Descricao = Descricao;
        }
    }
}
