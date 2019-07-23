using Sistema.Competicao.Domain.Entities.OrdemServico;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.OrdemServico
{
    public class LocalServicoBU
    {
        private readonly IRepository<LocalServicoEN> _localServicoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LocalServicoBU(IRepository<LocalServicoEN> localServicoRepository, IUnitOfWork unitOfWork)
        {
            _localServicoRepository = localServicoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDLocal, string Nome, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF)
        {
            LocalServicoEN LocalServicoEN = _localServicoRepository.GetByID(IDLocal);

            if (LocalServicoEN != null)
            {
                LocalServicoEN.UpdateProperties(Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _localServicoRepository.Edit(LocalServicoEN);
            }
            else
            {
                LocalServicoEN = new LocalServicoEN(Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _localServicoRepository.Save(LocalServicoEN);
            }

            _unitOfWork.Commit();
        }
    }
}