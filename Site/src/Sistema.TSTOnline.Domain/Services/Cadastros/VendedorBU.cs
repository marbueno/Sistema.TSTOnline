using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Interfaces;
using System;

namespace Sistema.TSTOnline.Domain.Services.Cadastros
{
    public class VendedorBU
    {
        private readonly IRepository<VendedorEN> _vendedorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VendedorBU(IRepository<VendedorEN> vendedorRepository, IUnitOfWork unitOfWork)
        {
            _vendedorRepository = vendedorRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDVendedor, int IDCompany, int IDUser, string Nome, string RG, string CPF, DateTime DataNascimento, string Email, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, int IDEmpresa, string NomeContato, string Telefone, string WhatsApp, string Observacao)
        {
            VendedorEN vendedorEN = _vendedorRepository.GetByID(IDVendedor);

            if (vendedorEN != null)
            {
                vendedorEN.UpdateProperties(IDCompany, IDUser, Nome, RG, CPF, DataNascimento, Email, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, IDEmpresa, NomeContato, Telefone, WhatsApp, Observacao);

                _vendedorRepository.Edit(vendedorEN);
            }
            else
            {
                vendedorEN = new VendedorEN(IDCompany, IDUser, Nome, RG, CPF, DataNascimento, Email, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, IDEmpresa, NomeContato, Telefone, WhatsApp, Observacao);

                _vendedorRepository.Save(vendedorEN);
            }

            _unitOfWork.Commit();
        }
    }
}