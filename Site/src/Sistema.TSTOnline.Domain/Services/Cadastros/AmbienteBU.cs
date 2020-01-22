using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Interfaces;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.Cadastros
{
    public class AmbienteBU
    {
        private readonly IRepository<AmbienteEN> _ambienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AmbienteBU(IRepository<AmbienteEN> ambienteRepository, IUnitOfWork unitOfWork)
        {
            _ambienteRepository = ambienteRepository;
            _unitOfWork = unitOfWork;
        }

        public int Save (int IDCompany, int IDUser, string NomeEstab, string CepEstab, string EnderecoEstab, string NumEstab, string ComplementoEstab, string BairroEstab, string CidadeEstab, string UFEstab)
        {
            AmbienteEN ambienteEN = _ambienteRepository.Where(obj => obj.NomeEstab == NomeEstab).FirstOrDefault();

            if (ambienteEN == null)
            {
                ambienteEN = new AmbienteEN
                    (
                        IDCompany,
                        IDUser,
                        NomeEstab,
                        CepEstab,
                        EnderecoEstab,
                        NumEstab,
                        ComplementoEstab,
                        BairroEstab,
                        CidadeEstab,
                        UFEstab
                    );

                _ambienteRepository.Save(ambienteEN);

                _unitOfWork.Commit();
            }

            return ambienteEN.IDAmb;
        }
    }
}