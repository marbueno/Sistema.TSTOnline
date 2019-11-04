using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Estoque
{
    public class MovimentoEstoqueEN
    {
        [Key]
        public int IDMovimento { get; set; }
        public int IDCompany { get; set; }
        public int IDUser { get; set; }
        public DateTime DataMovimento { get; set; }
        public OrigemMovimentoEstoqueEnum Origem { get; set; }
        public int Chave { get; set; }
        public int IDProduto { get; set; }
        public TipoMovimentoEstoqueEnum Tipo { get; set; }
        public int Qtde { get; set; }
        public string Observacao { get; set; }

        private MovimentoEstoqueEN() { }

        public MovimentoEstoqueEN(int IDCompany, int IDUser, OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            ValidateAndSetProperties(IDCompany, IDUser, Origem, Chave, IDProduto, Tipo, Qtde, Observacao);
        }

        public void UpdateProperties(int IDCompany, int IDUser, OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            ValidateAndSetProperties(IDCompany, IDUser, Origem, Chave, IDProduto, Tipo, Qtde, Observacao);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(IDProduto == 0, "Fornecedor não informado.");
            DomainException.When(Qtde <= 0, "Qtde não pode ser menor ou igual a zero.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.Origem = Origem;
            this.Chave = Chave;
            this.IDProduto = IDProduto;
            this.Tipo = Tipo;
            this.Qtde = Qtde;
            this.Observacao = Observacao;
        }
    }
}
