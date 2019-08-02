using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.OrdemServico
{
    public class TipoServicoBU
    {
        private readonly IRepository<TipoServicoEN> _repositoryServico;
        private readonly IUnitOfWork _unitOfWork;

        public TipoServicoBU(IRepository<TipoServicoEN> repositoryServico, IUnitOfWork unitOfWork)
        {
            _repositoryServico = repositoryServico;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDTipoServico, string Descricao)
        {
            TipoServicoEN ServicoEN = _repositoryServico.GetByID(IDTipoServico);

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
                ServicoEN = new TipoServicoEN
                    (
                        Descricao
                    );

                _repositoryServico.Save(ServicoEN);
            }

            _unitOfWork.Commit();
        }
    }
}
