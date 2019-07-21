using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Cadastros
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

        public void Save(int IDFornecedor, string CNPJ, string RazaoSocial, string NomeFantasia, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF)
        {
            FornecedorEN fornecedorEN = _fornecedorRepository.GetByID(IDFornecedor);

            if (fornecedorEN != null)
            {
                fornecedorEN.UpdateProperties(CNPJ, RazaoSocial, NomeFantasia, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _fornecedorRepository.Edit(fornecedorEN);
            }
            else
            {
                fornecedorEN = new FornecedorEN(CNPJ, RazaoSocial, NomeFantasia, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _fornecedorRepository.Save(fornecedorEN);
            }

            _unitOfWork.Commit();
        }
    }
}