using System;

namespace Sistema.Competicao.Web.Areas.Admin.Models.Cadastros
{
    public class EquipeVM
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataFundacao { get; set; }
        public string DataFundacaoFormatada { get; set; }
        public string DDD1 { get; set; }
        public string Telefone1 { get; set; }
        public string DDD2 { get; set; }
        public string Telefone2 { get; set; }
        public bool ComQuadra { get; set; }
        public int? Quadra { get; set; }
        public string Horario { get; set; }
    }
}
