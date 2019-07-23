using Sistema.Competicao.Domain.Entities.OrdemServico;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.OrdemServico
{
    public class ServicoBU
    {
        private readonly IRepository<ServicoEN> _repositoryServico;
        private readonly IUnitOfWork _unitOfWork;

        public ServicoBU(IRepository<ServicoEN> repositoryServico, IUnitOfWork unitOfWork)
        {
            _repositoryServico = repositoryServico;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDServico, string Descricao)
        {
            ServicoEN ServicoEN = _repositoryServico.GetByID(IDServico);

            if (ServicoEN != null)
            {
                ServicoEN.UpdateProperties
                    (
                        Descricao
                    );

                _repositoryServico.Edit(ServicoEN);
            }
            else
            {
                ServicoEN = new ServicoEN
                    (
                        Descricao
                    );

                _repositoryServico.Save(ServicoEN);
            }

            _unitOfWork.Commit();
        }
    }
}
