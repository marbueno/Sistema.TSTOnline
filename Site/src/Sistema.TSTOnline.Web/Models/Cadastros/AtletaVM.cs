using System;

namespace Sistema.Competicao.Web.Areas.Admin.Models.Cadastros
{
    public class AtletaVM
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DataNascimentoFormatada { get; set; }
        public int Posicao { get; set; }
        public int Equipe { get; set; }
        public bool PrimeiroQuadro { get; set; }
        public bool SegundoQuadro { get; set; }
        public bool IsentoPagamento { get; set; }
        public string Foto { get; set; }
    }
}
