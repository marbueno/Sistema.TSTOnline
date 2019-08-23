using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Services.Estoque
{
    public class MovimentoEstoqueBU
    {
        private readonly IRepository<MovimentoEstoqueEN> _repositoryMovimentoEstoque;
        private readonly EstoqueBU _estoqueBU;
        private readonly IUnitOfWork _unitOfWork;

        public MovimentoEstoqueBU(IRepository<MovimentoEstoqueEN> repositoryMovimentoEstoque, EstoqueBU estoqueBU, IUnitOfWork unitOfWork)
        {
            _repositoryMovimentoEstoque = repositoryMovimentoEstoque;
            _estoqueBU = estoqueBU;
            _unitOfWork = unitOfWork;
        }

        public void Save(OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            MovimentoEstoqueEN movimentoEstoqueEN = new MovimentoEstoqueEN
                (
                    Origem,
                    Chave,
                    IDProduto,
                    Tipo,
                    Qtde,
                    Observacao
                );
            movimentoEstoqueEN.DataMovimento = DateTime.Now;

            _repositoryMovimentoEstoque.Save(movimentoEstoqueEN);

            _estoqueBU.AtualizarEstoque(IDProduto, Tipo, Qtde);

            _unitOfWork.Commit();
        }
    }
}
