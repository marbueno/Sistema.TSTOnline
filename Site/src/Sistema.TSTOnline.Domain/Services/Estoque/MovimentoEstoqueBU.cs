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

        public void Save(int IDCompany, int IDUser, OrigemMovimentoEstoqueEnum Origem, int Chave, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, string Observacao)
        {
            MovimentoEstoqueEN movimentoEstoqueEN = new MovimentoEstoqueEN
                (
                    IDCompany,
                    IDUser,
                    Origem,
                    Chave,
                    IDProduto,
                    Tipo,
                    Qtde,
                    Observacao
                );
            movimentoEstoqueEN.DataMovimento = DateTime.Now.ToLocalTime();

            _repositoryMovimentoEstoque.Save(movimentoEstoqueEN);

            _estoqueBU.AtualizarEstoque(IDCompany, IDUser, IDProduto, Tipo, Qtde);

            _unitOfWork.Commit();
        }
    }
}
