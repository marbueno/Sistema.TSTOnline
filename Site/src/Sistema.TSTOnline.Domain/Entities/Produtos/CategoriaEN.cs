using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Produtos
{
    public class CategoriaEN
    {
        [Key]
        public int IDCategoria { get; set; }
        public string Descricao { get; set; }

        private CategoriaEN() { }

        public CategoriaEN(string Descricao)
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
