using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Estoque
{
    public class MovimentoEstoqueEN
    {
        [Key]
        public int IDMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
        public OrigemMovimentoEstoqueEnum Origem { get; set; }
        public int Chave { get; set; }
        public int IDProduto { get; set; }
        public TipoMovimentoEstoqueEnum Tipo { get; set; }
        public int Qtde { get; set; }
        public string Observacao { get; set; }

        private MovimentoEstoqueEN() { }

        public MovimentoEstoqueEN(OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            ValidateAndSetProperties(Origem, Chave, IDProduto, Tipo, Qtde, Observacao);
        }

        public void UpdateProperties(OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            ValidateAndSetProperties(Origem, Chave, IDProduto, Tipo, Qtde, Observacao);
        }

        private void ValidateAndSetProperties(OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            DomainException.When(IDProduto == 0, "Fornecedor não informado.");
            DomainException.When(Qtde <= 0, "Qtde não pode ser menor ou igual a zero.");

            this.Origem = Origem;
            this.Chave = Chave;
            this.IDProduto = IDProduto;
            this.Tipo = Tipo;
            this.Qtde = Qtde;
            this.Observacao = Observacao;
        }
    }
}
