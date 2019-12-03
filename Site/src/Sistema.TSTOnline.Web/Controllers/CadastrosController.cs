using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Cadastros;
using Sistema.TSTOnline.Domain.Services.Usuario;
using Sistema.TSTOnline.Web.Models.Cadastros;

namespace Sistema.TSTOnline.Web.Areas.Admin.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class CadastrosController : Controller
    {
        #region Variables

        private readonly IRepository<EmpresaEN> _empresaRepository;

        private readonly IRepository<FornecedorEN> _fornecedorRepository;
        private readonly FornecedorBU _fornecedorBU;

        private readonly IRepository<ResponsavelEN> _responsavelRepository;

        private readonly IRepository<VendedorEN> _vendedorRepository;
        private readonly VendedorBU _vendedorBU;

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private int idUser => _usuarioService.GetUserId();
        
        #endregion Variables

        #region Constructor

        public CadastrosController(
                IRepository<EmpresaEN> empresaRepository,
                IRepository<FornecedorEN> fornecedorRepository, FornecedorBU fornecedorBU,
                IRepository<ResponsavelEN> responsavelRepository,
                IRepository<VendedorEN> vendedorRepository, VendedorBU vendedorBU,
                UsuarioService usuarioService
            )
        {
            _empresaRepository = empresaRepository;

            _fornecedorRepository = fornecedorRepository;
            _fornecedorBU = fornecedorBU;

            _responsavelRepository = responsavelRepository;

            _vendedorRepository = vendedorRepository;
            _vendedorBU = vendedorBU;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Empresa

        [HttpGet]
        [Route("listEmpresas")]
        public JsonResult ListEmpresas()
        {
            var listEmpresa = _empresaRepository.Where(obj => obj.IDCompany == idCompany && obj.StatusEmpresa == "a").ToList();
            var empresaVM = listEmpresa.Select(
                c => new EmpresaVM
                {
                    IDEmpresa = c.IDEmpresa,
                    RazaoSocial = c.RazaoSocial,
                    NomeFantasia = c.NomeFantasia,
                    NomeRespEmpresa = c.NomeRespEmpresa,
                    CPFResponsavel = c.CPFResponsavel,
                    TelResponsavel = c.TelResponsavel,
                    NitResponsavel = c.NitResponsavel,
                    EmailResponsavel = c.EmailResponsavel
                });

            return Json(empresaVM);
        }

        #endregion Empresa

        #region Fornecedor

        [HttpGet]
        [Route("fornecedor")]
        public IActionResult Fornecedor(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("fornecedorAddEdit/{idFornecedor?}")]
        public IActionResult FornecedorAddEdit(int? idFornecedor)
        {
            if (idFornecedor != null)
            {
                var fornecedor = _fornecedorRepository.GetByID(idFornecedor ?? 0);

                var fornecedorVM = new FornecedorVM()
                {
                    IDFornecedor = fornecedor.IDFornecedor,
                    CNPJ = fornecedor.CNPJ,
                    RazaoSocial = fornecedor.RazaoSocial,
                    NomeFantasia = fornecedor.NomeFantasia,
                    CEP = fornecedor.CEP,
                    Endereco = fornecedor.Endereco,
                    Numero = fornecedor.Numero,
                    Complemento = fornecedor.Complemento,
                    Bairro = fornecedor.Bairro,
                    Cidade = fornecedor.Cidade,
                    UF = fornecedor.UF,
                    NomeContato = fornecedor.NomeContato,
                    Telefone = fornecedor.Telefone,
                    WhatsApp = fornecedor.WhatsApp
                };

                return View(fornecedorVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listFornecedores")]
        public JsonResult ListFornecedores()
        {
            var listFornecedor = _fornecedorRepository.Where(obj => obj.IDCompany == idCompany).ToList();
            var fornecedorVM = listFornecedor.Select(
                c => new FornecedorVM
                {
                    IDFornecedor = c.IDFornecedor,
                    CNPJ = c.CNPJ,
                    RazaoSocial = c.RazaoSocial,
                    NomeFantasia = c.NomeFantasia,
                    CEP = c.CEP,
                    Endereco = c.Endereco,
                    Numero = c.Numero,
                    Complemento = c.Complemento,
                    Bairro = c.Bairro,
                    Cidade = c.Cidade,
                    UF = c.UF,
                    NomeContato = c.NomeContato,
                    Telefone = c.Telefone,
                    WhatsApp = c.WhatsApp
                });

            return Json(fornecedorVM.ToList());
        }

        [HttpPost]
        [Route("fornecedorCreateOrUpdate")]
        public IActionResult FornecedorCreateOrUpdate(FornecedorVM fornecedorVM)
        {
            _fornecedorBU.Save
                (
                    fornecedorVM.IDFornecedor,
                    idCompany,
                    idUser,
                    fornecedorVM.CNPJ,
                    fornecedorVM.RazaoSocial,
                    fornecedorVM.NomeFantasia,
                    fornecedorVM.CEP,
                    fornecedorVM.Endereco,
                    fornecedorVM.Numero,
                    fornecedorVM.Complemento,
                    fornecedorVM.Bairro,
                    fornecedorVM.Cidade,
                    fornecedorVM.UF,
                    fornecedorVM.NomeContato,
                    fornecedorVM.Telefone,
                    fornecedorVM.WhatsApp
               );

            return Ok();
        }

        [HttpDelete]
        [Route("fornecedorDelete/{id}")]
        public IActionResult FornecedorDelete(int id)
        {
            _fornecedorRepository.Delete(id);

            return Ok();
        }

        #endregion Vendedor

        #region Responsáveis

        [HttpGet]
        [Route("listResponsaveis")]
        public JsonResult ListResponsaveis()
        {
            var listResponsaveis = _responsavelRepository.Where(obj => obj.IDCompany == idCompany).ToList();
            var responsavelVM = listResponsaveis.Select(
                c => new ResponsavelVM
                {
                    IDResp = c.IDResp,
                    IDUser = c.IDUser,
                    IDCompany = c.IDCompany,
                    CodResp = c.CodResp,
                    StatusResp = c.StatusResp,
                    Situacao = c.Situacao,
                    NomeResponsavel = c.NomeResponsavel,
                    IdentProfissional = c.IdentProfissional,
                    Numero = c.Numero,
                    UF = c.UF,
                    PD = c.PD,
                    CPF = c.CPF,
                    RG = c.RG,
                    NIT = c.NIT,
                    Telefone = c.Telefone,
                    TelComercial = c.TelComercial,
                    Celular = c.Celular,
                    Email = c.Email,
                    Obs = c.Obs
                });

            return Json(responsavelVM);
        }

        #endregion Empresa

        #region Vendedor

        [HttpGet]
        [Route("vendedor")]
        public IActionResult Vendedor(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("vendedorAddEdit/{idVendedor?}")]
        public IActionResult VendedorAddEdit(int? idVendedor)
        {
            if (idVendedor != null)
            {
                var vendedor = _vendedorRepository.GetByID(idVendedor ?? 0);

                var vendedorVM = new VendedorVM()
                {
                    IDVendedor = vendedor.IDVendedor,
                    Nome = vendedor.Nome,
                    RG = vendedor.RG,
                    CPF = vendedor.CPF,
                    DataNascimento = vendedor.DataNascimento,
                    Email = vendedor.Email,
                    CEP = vendedor.CEP,
                    Endereco = vendedor.Endereco,
                    Numero = vendedor.Numero,
                    Complemento = vendedor.Complemento,
                    Bairro = vendedor.Bairro,
                    Cidade = vendedor.Cidade,
                    UF = vendedor.UF,
                    IDEmpresa = vendedor.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(vendedor.IDEmpresa).RazaoSocial,
                    NomeContato = vendedor.NomeContato,
                    Telefone = vendedor.Telefone,
                    WhatsApp = vendedor.WhatsApp,
                    Observacao = vendedor.Observacao
                };

                return View(vendedorVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listVendedores")]
        public JsonResult ListVendedores()
        {
            var listVendedor = _vendedorRepository.Where(obj => obj.IDCompany == idCompany).ToList();
            var vendedorVM = listVendedor.Select(
                c => new VendedorVM
                {
                    IDVendedor = c.IDVendedor,
                    Nome = c.Nome,
                    RG = c.RG,
                    CPF = c.CPF,
                    DataNascimento = c.DataNascimento,
                    Email = c.Email,
                    CEP = c.CEP,
                    Endereco = c.Endereco,
                    Numero = c.Numero,
                    Complemento = c.Complemento,
                    Bairro = c.Bairro,
                    Cidade = c.Cidade,
                    UF = c.UF,
                    IDEmpresa = c.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(c.IDEmpresa).RazaoSocial,
                    NomeContato = c.NomeContato,
                    Telefone = c.Telefone,
                    WhatsApp = c.WhatsApp
                });

            return Json(vendedorVM.ToList());
        }

        [HttpPost]
        [Route("vendedorCreateOrUpdate")]
        public IActionResult VendedorCreateOrUpdate(VendedorVM vendedorVM)
        {
            _vendedorBU.Save
                (
                    vendedorVM.IDVendedor,
                    idCompany,
                    idUser,
                    vendedorVM.Nome,
                    vendedorVM.RG,
                    vendedorVM.CPF, 
                    vendedorVM.DataNascimento,
                    vendedorVM.Email,
                    vendedorVM.CEP,
                    vendedorVM.Endereco, 
                    vendedorVM.Numero, 
                    vendedorVM.Complemento, 
                    vendedorVM.Bairro, 
                    vendedorVM.Cidade, 
                    vendedorVM.UF,
                    vendedorVM.IDEmpresa,
                    vendedorVM.NomeContato,
                    vendedorVM.Telefone,
                    vendedorVM.WhatsApp,
                    vendedorVM.Observacao
               );

            return Ok();
        }

        [HttpDelete]
        [Route("vendedorDelete/{id}")]
        public IActionResult VendedorDelete(int id)
        {
            _vendedorRepository.Delete(id);

            return Ok();
        }

        #endregion Vendedor
    }
}