namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class VendasPorProdutoEN
    {
        public int Id { get; set; }
        public int IDPedido { get; set; }
        public int Item { get; set; }
        public string Produto { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
