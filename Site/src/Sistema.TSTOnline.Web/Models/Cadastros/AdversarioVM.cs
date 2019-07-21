namespace Sistema.Competicao.Web.Areas.Admin.Models.Cadastros
{
    public class AdversarioVM
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public int DDD1 { get; set; }
        public int Telefone1 { get; set; }
        public int? DDD2 { get; set; }
        public int? Telefone2 { get; set; }
        public bool ComQuadra { get; set; }
        public int? Quadra { get; set; }
    }
}
