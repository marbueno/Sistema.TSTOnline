namespace Sistema.TSTOnline.Domain.Templates.Relatorios
{
    public class OrdemServicoDetalhadaTemplate
    {
        public string LogoTipo { get; set; }
        public string DataInclusao { get; set; }
        public string HorarioInclusao { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string ClienteFiltro { get; set; }
        public string ResponsavelFiltro { get; set; }
        public string StatusFiltro { get; set; }
        public string ConteudoRelatorio { get; set; }
        public string DataInclusaoPorExtenso { get; set; }
    }
}
