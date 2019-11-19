namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class OrdemServicoPorTipoEN
    {
        public int Id { get; set; }
        public int IDOrdemServico { get; set; }
        public int Item { get; set; }
        public string TipoServico { get; set; }
        public string Observacao { get; set; }
        public bool Concluido { get; set; }
    }
}
