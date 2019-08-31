using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira;
using Sistema.TSTOnline.Web.Models.MovimentacaoFinanceira;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;
using Sistema.TSTOnline.Domain.Services.Fluxo;
using Sistema.TSTOnline.Domain.Entities.Cadastros;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class MovimentacaoFinanceiraController : Controller
    {
        #region Variables

        private readonly IRepository<ContasReceberEN> _contasReceberRepository;
        private readonly ContasReceberBU _contasReceberBU;
        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly FluxoBU _fluxoBU;

        #endregion Variables

        #region Constructor

        public MovimentacaoFinanceiraController
            (
                IRepository<ContasReceberEN> contasReceberRepository, ContasReceberBU contasReceberBU,
                IRepository<EmpresaEN> empresaRepository,
                FluxoBU fluxoBU
            )
        {
            _contasReceberRepository = contasReceberRepository;
            _contasReceberBU = contasReceberBU;

            _empresaRepository = empresaRepository;

            _fluxoBU = fluxoBU;
        }

        #endregion Constructor

        #region Contas a Receber

        [HttpGet]
        [Route("contasReceber")]
        public IActionResult ContasReceber()
        {
            return View();
        }

        [HttpGet]
        [Route("contasReceberAddEdit/{idContasReceber?}")]
        public IActionResult ContasReceberAddEdit(int? idContasReceber)
        {
            if (idContasReceber != null)
            {
                var contasReceber = _contasReceberRepository.GetByID(idContasReceber ?? 0);

                var contasReceberVM = new ContasReceberVM()
                {
                    IDContasReceber = contasReceber.IDContasReceber,
                    DataCadastro = contasReceber.DataCadastro,
                    IDEmpresa = contasReceber.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(contasReceber.IDEmpresa).RazaoSocial,
                    NumeroTitulo = contasReceber.NumeroTitulo,
                    DataVencimento = contasReceber.DataVencimento,
                    Valor = contasReceber.Valor,
                    ValorPago = contasReceber.ValorPago,
                    Origem = contasReceber.Origem,
                    Chave = contasReceber.Chave,
                    Status = contasReceber.Status
                };

                return View(contasReceberVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listContasReceber")]
        public JsonResult ListContasReceber()
        {
            var listContasReceber = _contasReceberRepository.All();
            var contasReceberVM = listContasReceber.Select(
                c => new ContasReceberVM
                {
                    IDContasReceber = c.IDContasReceber,
                    DataCadastro = c.DataCadastro,
                    IDEmpresa = c.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(c.IDEmpresa).RazaoSocial,
                    NumeroTitulo = c.NumeroTitulo,
                    DataVencimento = c.DataVencimento,
                    Valor = c.Valor,
                    ValorPago = c.ValorPago,
                    Origem = c.Origem,
                    Chave = c.Chave,
                    Status = c.Status
                });

            return Json(contasReceberVM.ToList());
        }

        [HttpPost]
        [Route("contasReceberCreateOrUpdate")]
        public IActionResult ContasReceberCreateOrUpdate([FromBody] ContasReceberVM contasReceberVM)
        {
            _contasReceberBU.Save
                (
                    contasReceberVM.IDContasReceber,
                    contasReceberVM.IDEmpresa,
                    contasReceberVM.NumeroTitulo,
                    contasReceberVM.DataVencimento,
                    contasReceberVM.Valor,
                    contasReceberVM.ValorPago,
                    OrigemContasReceberEnum.ContasReceber,
                    0
               );

            return Ok();
        }

        [HttpPut]
        [Route("alterarStatusContasReceber/{id}/{status}")]
        public IActionResult ContasReceberAlterarStatus(int id, ContasReceberStatusEnum Status)
        {
            _fluxoBU.FluxoContasReceber(id, Status);

            return Ok();
        }

        #endregion Contas a Receber
    }
}