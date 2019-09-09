using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.OrdemServico
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

        public void Save(int IDLocal, string Nome, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp)
        {
            LocalServicoEN LocalServicoEN = _localServicoRepository.GetByID(IDLocal);

            if (LocalServicoEN != null)
            {
                LocalServicoEN.UpdateProperties(Nome, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);

                _localServicoRepository.Edit(LocalServicoEN);
            }
            else
            {
                LocalServicoEN = new LocalServicoEN(Nome, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);

                _localServicoRepository.Save(LocalServicoEN);
            }

            _unitOfWork.Commit();
        }
    }
}