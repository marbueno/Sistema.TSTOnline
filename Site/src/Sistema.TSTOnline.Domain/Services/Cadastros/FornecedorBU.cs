using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.Cadastros
{
    public class FornecedorBU
    {
        private readonly IRepository<FornecedorEN> _fornecedorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FornecedorBU(IRepository<FornecedorEN> fornecedorRepository, IUnitOfWork unitOfWork)
        {
            _fornecedorRepository = fornecedorRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDFornecedor, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp)
        {
            FornecedorEN fornecedorEN = _fornecedorRepository.GetByID(IDFornecedor);

            if (fornecedorEN != null)
            {
                fornecedorEN.UpdateProperties(CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);

                _fornecedorRepository.Edit(fornecedorEN);
            }
            else
            {
                fornecedorEN = new FornecedorEN(CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);

                _fornecedorRepository.Save(fornecedorEN);
            }

            _unitOfWork.Commit();
        }
    }
}