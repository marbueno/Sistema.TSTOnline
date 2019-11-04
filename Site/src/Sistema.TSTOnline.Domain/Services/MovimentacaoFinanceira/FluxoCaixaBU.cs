using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira
{
    public class FluxoCaixaBU
    {
        private readonly IRepository<FluxoCaixaEN> _repositoryFluxoCaixa;
        private readonly IUnitOfWork _unitOfWork;

        public FluxoCaixaBU (IRepository<FluxoCaixaEN> repositoryFluxoCaixa, IUnitOfWork unitOfWork)
        {
            _repositoryFluxoCaixa = repositoryFluxoCaixa;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDFluxoCaixa, int IDCompany, int IDUser, DateTime DataLancamento, TipoLancamentoFluxoCaixaEnum TipoLancamento, OrigemFluxoCaixaEnum Origem, int Chave, decimal Valor, string Observacao)
        {
            FluxoCaixaEN fluxoCaixaEN = null;

            if (Origem == OrigemFluxoCaixaEnum.FluxoCaixa)
            {
                fluxoCaixaEN = _repositoryFluxoCaixa.GetByID(IDFluxoCaixa);
            }
            else
            {
                fluxoCaixaEN = _repositoryFluxoCaixa.Where(obj => obj.Chave == Chave).FirstOrDefault();
            }

            if (fluxoCaixaEN != null)
            {
                fluxoCaixaEN.UpdateProperties
                    (
                        IDCompany,
                        IDUser,
                        DataLancamento,
                        TipoLancamento,
                        Origem,
                        Chave,
                        Valor,
                        Observacao
                    );

                _repositoryFluxoCaixa.Edit(fluxoCaixaEN);
            }
            else
            {
                fluxoCaixaEN = new FluxoCaixaEN
                    (
                        IDCompany,
                        IDUser,
                        DataLancamento,
                        TipoLancamento,
                        Origem,
                        Chave,
                        Valor,
                        Observacao
                    );

                _repositoryFluxoCaixa.Save(fluxoCaixaEN);
            }

            _unitOfWork.Commit();

            return fluxoCaixaEN.IDFluxoCaixa;
        }
    }
}
