using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Interfaces;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.Cadastros
{
    public class EmpresaBU
    {
        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaBU(IRepository<EmpresaEN> empresaRepository, IUnitOfWork unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
        }

        public int Save (int IDCompany, int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string Telefone, string Celular, string NomeRespEmpresa, string CPFResponsavel, string TelResponsavel, string EmailResponsavel)
        {
            EmpresaEN empresaEN = _empresaRepository.Where(obj => obj.NrMatricula == CNPJ).FirstOrDefault();

            if (empresaEN == null)
            {
                empresaEN = new EmpresaEN
                    (
                        IDCompany,
                        IDUser,
                        CNPJ,
                        RazaoSocial,
                        NomeFantasia,
                        CEP,
                        Endereco,
                        Numero,
                        Complemento,
                        Bairro,
                        Cidade,
                        UF,
                        Telefone,
                        Celular,
                        NomeRespEmpresa, 
                        CPFResponsavel, 
                        TelResponsavel, 
                        EmailResponsavel
                    );

                _empresaRepository.Save(empresaEN);

                _unitOfWork.Commit();
            }


            return empresaEN.IDEmpresa;
        }
    }
}