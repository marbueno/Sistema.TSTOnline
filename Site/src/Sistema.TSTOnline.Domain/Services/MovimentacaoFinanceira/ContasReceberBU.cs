using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira
{
    public class ContasReceberBU
    {
        private readonly IRepository<ContasReceberEN> _repositoryContasReceber;
        private readonly IUnitOfWork _unitOfWork;

        public ContasReceberBU (IRepository<ContasReceberEN> repositoryContasReceber, IUnitOfWork unitOfWork)
        {
            _repositoryContasReceber = repositoryContasReceber;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDContasReceber, string NumeroTitulo, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave)
        {
            ContasReceberEN contasReceberEN = null;

            if (Origem == OrigemContasReceberEnum.ContasReceber)
            {
                contasReceberEN = _repositoryContasReceber.GetByID(IDContasReceber);
            }
            else
            {
                contasReceberEN = _repositoryContasReceber.Where(obj => obj.Chave == Chave).FirstOrDefault();
            }

            if (contasReceberEN != null)
            {
                contasReceberEN.UpdateProperties
                    (
                        NumeroTitulo,
                        DataVencimento,
                        Valor,
                        ValorPago,
                        Origem,
                        Chave,
                        contasReceberEN.Status
                    );

                _repositoryContasReceber.Edit(contasReceberEN);
            }
            else
            {
                contasReceberEN = new ContasReceberEN
                    (
                        NumeroTitulo,
                        DataVencimento,
                        Valor,
                        ValorPago,
                        Origem,
                        Chave,
                        ContasReceberStatusEnum.EmAberto
                    );
                contasReceberEN.DataCadastro = DateTime.Now;

                _repositoryContasReceber.Save(contasReceberEN);
            }

            _unitOfWork.Commit();

            return contasReceberEN.IDContasReceber;
        }
    }
}
