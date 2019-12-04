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

        public int Save(int IDContasReceber, int IDCompany, int IDUser, int IDEmpresa, string NumeroTitulo, int Seq, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, string linkFatura, int Chave, string Observaca)
        {
            ContasReceberEN contasReceberEN = null;

            if (Origem == OrigemContasReceberEnum.ContasReceber)
            {
                contasReceberEN = _repositoryContasReceber.GetByID(IDContasReceber);
            }
            else
            {
                contasReceberEN = _repositoryContasReceber.Where(obj => obj.Chave == Chave && obj.Seq == Seq).FirstOrDefault();
            }

            if (contasReceberEN != null)
            {
                contasReceberEN.UpdateProperties
                    (
                        IDCompany,
                        IDUser,
                        IDEmpresa,
                        NumeroTitulo,
                        Seq,
                        DataVencimento,
                        Valor,
                        ValorPago,
                        Origem,
                        Chave,
                        linkFatura,
                        contasReceberEN.Status,
                        Observaca
                    );

                _repositoryContasReceber.Edit(contasReceberEN);
            }
            else
            {
                contasReceberEN = new ContasReceberEN
                    (
                        IDCompany,
                        IDUser,
                        IDEmpresa,
                        NumeroTitulo,
                        Seq,
                        DataVencimento,
                        Valor,
                        ValorPago,
                        Origem,
                        Chave,
                        linkFatura,
                        ContasReceberStatusEnum.EmAberto,
                        Observaca
                    );
                contasReceberEN.DataCadastro = DateTime.Now.ToLocalTime();

                _repositoryContasReceber.Save(contasReceberEN);
            }

            _unitOfWork.Commit();

            return contasReceberEN.IDContasReceber;
        }
    }
}
