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

        public void Save(int IDVendedor, string Nome, string RG, string CPF, DateTime DataNascimento, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF)
        {
            VendedorEN vendedorEN = _vendedorRepository.GetByID(IDVendedor);

            if (vendedorEN != null)
            {
                vendedorEN.UpdateProperties(Nome, RG, CPF, DataNascimento, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _vendedorRepository.Edit(vendedorEN);
            }
            else
            {
                vendedorEN = new VendedorEN(Nome, RG, CPF, DataNascimento, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF);

                _vendedorRepository.Save(vendedorEN);
            }

            _unitOfWork.Commit();
        }
    }
}