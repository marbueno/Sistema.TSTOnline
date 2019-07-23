using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Cadastros;
using Sistema.Competicao.Web.Areas.Admin.Models.Cadastros;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CadastrosController : Controller
    {
        #region Variables

        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly EmpresaBU _empresaBU;

        private readonly IRepository<VendedorEN> _vendedorRepository;
        private readonly VendedorBU _vendedorBU;

        #endregion Variables

        #region Constructor

        public CadastrosController(
                IRepository<EmpresaEN> empresaRepository, EmpresaBU empresaBU,
                IRepository<VendedorEN> vendedorRepository, VendedorBU vendedorBU)
        {
            _empresaRepository = empresaRepository;
            _empresaBU = empresaBU;

            _vendedorRepository = vendedorRepository;
            _vendedorBU = vendedorBU;
        }

        #endregion Constructor

        #region Empresa

        public IActionResult Empresa()
        {
            return View();
        }

        public JsonResult ListEmpresas()
        {
            var listEmpresa = _empresaRepository.All();
            var empresaVM = listEmpresa.Select(
                c => new EmpresaVM
                {
                    IDEmpresa = c.IDEmpresa,
                    StatusEmpresa = c.StatusEmpresa,
                    Situacao = c.Situacao,
                    IDUser = c.IDUser,
                    NomeContato = c.NomeContato,
                    CPFContato = c.CPFContato,
                    TelContato = c.TelContato,
                    NomeRespEmpresa = c.NomeRespEmpresa,
                    CPFResponsavel = c.CPFResponsavel,
                    TelResponsavel = c.TelResponsavel,
                    NITResponsavel = c.NITResponsavel,
                    EmailResponsavel = c.EmailResponsavel,
                    CodEmpresa = c.CodEmpresa,
                    RazaoSocial = c.RazaoSocial,
                    NomeFantasia = c.NomeFantasia,
                    TipoMatricula = c.TipoMatricula,
                    NRMatricula = c.NRMatricula,
                    CNAE = c.CNAE,
                    CNAEDesc = c.CNAEDesc,
                    CEP = c.CEP,
                    UF = c.UF,
                    Cidade = c.Cidade,
                    Bairro = c.Bairro,
                    Endereco = c.Endereco,
                    Numero = c.Numero,
                    Complemento = c.Complemento,
                    Telefone = c.Telefone,
                    Celular = c.Celular,
                    Email = c.Email
                });

            return Json(empresaVM);
        }

        #endregion Empresa

        #region Vendedor

        public IActionResult Vendedor()
        {
            return View();
        }

        public JsonResult ListVendedores()
        {
            var listVendedor = _vendedorRepository.All();
            var vendedorVM = listVendedor.Select(
                c => new Vendedor
                {
                    IDVendedor = c.IDVendedor,
                    Nome = c.Nome,
                    CPF = c.CPF == null ? string.Empty : c.CPF.ToString(),
                    Endereco = c.Endereco,
                    Numero = c.Numero,
                    Complemento = c.Complemento,
                    Bairro = c.Bairro,
                    Cidade = c.Cidade,
                    UF = c.UF
                });

            return Json(vendedorVM.OrderBy(o => o.Nome).ToList());
        }

        [HttpPost]
        public IActionResult VendedorCreateOrUpdate(Vendedor vendedorVM)
        {
            _vendedorBU.Save
                (
                    vendedorVM.IDVendedor, 
                    vendedorVM.Nome, 
                    vendedorVM.CPF, 
                    vendedorVM.Endereco, 
                    vendedorVM.Numero, 
                    vendedorVM.Complemento, 
                    vendedorVM.Bairro, 
                    vendedorVM.Cidade, 
                    vendedorVM.UF
               );

            return Ok();
        }

        [HttpDelete]
        public IActionResult VendedorRemove(int id)
        {
            _vendedorRepository.Delete(id);

            return Ok();
        }

        #endregion Vendedor
    }
}