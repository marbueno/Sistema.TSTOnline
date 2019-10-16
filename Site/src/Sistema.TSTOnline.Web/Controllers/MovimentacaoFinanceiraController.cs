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
using Sistema.TSTOnline.Domain.Services.Template;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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

        private readonly IRepository<FluxoCaixaEN> _fluxoCaixaRepository;
        private readonly FluxoCaixaBU _fluxoCaixaBU;

        private readonly FluxoBU _fluxoBU;

        private readonly IConfiguration _configuration;

        private readonly TemplateBU _templateBU;

        #endregion Variables

        #region Constructor

        public MovimentacaoFinanceiraController
            (
                IRepository<ContasReceberEN> contasReceberRepository, ContasReceberBU contasReceberBU,
                IRepository<EmpresaEN> empresaRepository,
                IRepository<FluxoCaixaEN> fluxoCaixaRepository, FluxoCaixaBU fluxoCaixaBU,
                FluxoBU fluxoBU,
                IConfiguration configuration,
                TemplateBU templateBU
            )
        {
            _contasReceberRepository = contasReceberRepository;
            _contasReceberBU = contasReceberBU;

            _empresaRepository = empresaRepository;

            _fluxoCaixaRepository = fluxoCaixaRepository;
            _fluxoCaixaBU = fluxoCaixaBU;

            _fluxoBU = fluxoBU;

            _configuration = configuration;

            _templateBU = templateBU;
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
                    Seq = contasReceber.Seq,
                    DataVencimento = contasReceber.DataVencimento,
                    Valor = contasReceber.Valor,
                    ValorPago = contasReceber.ValorPago,
                    Origem = contasReceber.Origem,
                    Chave = contasReceber.Chave,
                    LinkFatura = contasReceber.LinkFatura,
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
                    Seq = c.Seq,
                    DataVencimento = c.DataVencimento,
                    Valor = c.Valor,
                    ValorPago = c.ValorPago,
                    Origem = c.Origem,
                    Chave = c.Chave,
                    LinkFatura = c.LinkFatura,
                    Status = c.Status
                });

            return Json(contasReceberVM.ToList());
        }

        [HttpPost]
        [Route("contasReceberCreateOrUpdate")]
        public IActionResult ContasReceberCreateOrUpdate(ContasReceberVM contasReceberVM)
        {
            _contasReceberBU.Save
                (
                    contasReceberVM.IDContasReceber,
                    contasReceberVM.IDEmpresa,
                    contasReceberVM.NumeroTitulo,
                    1,
                    contasReceberVM.DataVencimento,
                    contasReceberVM.Valor,
                    contasReceberVM.ValorPago,
                    OrigemContasReceberEnum.ContasReceber,
                    contasReceberVM.LinkFatura,
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

        [HttpPut]
        [Route("contasReceberGerarFatura/{id}")]
        public IActionResult ContasReceberGerarFatura(int id)
        {
            string emailCopia = _configuration.GetSection("Environment:Email").Value;
            _fluxoBU.GerarFatura(id, emailCopia);

            return Ok();
        }

        #endregion Contas a Receber

        #region Fluxo de Caixa

        [HttpGet]
        [Route("fluxoCaixa")]
        public IActionResult FluxoCaixa()
        {
            return View();
        }

        [HttpGet]
        [Route("fluxoCaixaAddEdit/{idFluxoCaixa?}")]
        public IActionResult FluxoCaixaAddEdit(int? idFluxoCaixa)
        {
            if (idFluxoCaixa != null)
            {
                var fluxoCaixa = _fluxoCaixaRepository.GetByID(idFluxoCaixa ?? 0);

                var fluxoCaixaVM = new FluxoCaixaVM()
                {
                    IDFluxoCaixa = fluxoCaixa.IDFluxoCaixa,
                    DataLancamento = fluxoCaixa.DataLancamento,
                    TipoLancamento = fluxoCaixa.TipoLancamento,
                    Origem = fluxoCaixa.Origem,
                    Chave = fluxoCaixa.Chave,
                    Valor = fluxoCaixa.Valor,
                    Observacao = fluxoCaixa.Observacao
                };

                return View(fluxoCaixaVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listFluxoCaixa")]
        public JsonResult ListFluxoCaixa()
        {
            var listFluxoCaixa = _fluxoCaixaRepository.All();
            var listFluxoCaixaVM = new List<FluxoCaixaVM>();

            foreach (var itemCaixa in listFluxoCaixa)
            {
                FluxoCaixaVM fluxoCaixaVM = new FluxoCaixaVM();

                fluxoCaixaVM.IDFluxoCaixa = itemCaixa.IDFluxoCaixa;
                fluxoCaixaVM.DataLancamento = itemCaixa.DataLancamento;
                fluxoCaixaVM.TipoLancamento = itemCaixa.TipoLancamento;
                fluxoCaixaVM.Origem = itemCaixa.Origem;
                fluxoCaixaVM.Chave = itemCaixa.Chave;
                fluxoCaixaVM.Valor = itemCaixa.Valor;
                fluxoCaixaVM.Observacao = itemCaixa.Observacao;
                fluxoCaixaVM.RazaoSocial = string.Empty;

                if (itemCaixa.Origem == OrigemFluxoCaixaEnum.ContasReceber)
                {
                    var contasReceberEN = _contasReceberRepository.GetByID(itemCaixa.Chave);

                    if (contasReceberEN != null)
                    {
                        var empresaEN = _empresaRepository.GetByID(contasReceberEN.IDEmpresa);

                        if (empresaEN != null)
                        {
                            fluxoCaixaVM.RazaoSocial = empresaEN.RazaoSocial;
                        }
                    }
                }

                listFluxoCaixaVM.Add(fluxoCaixaVM);

            }

            return Json(listFluxoCaixaVM.ToList());
        }

        [HttpPost]
        [Route("fluxoCaixaCreateOrUpdate")]
        public IActionResult FluxoCaixaCreateOrUpdate(FluxoCaixaVM fluxoCaixaVM)
        {
            _fluxoCaixaBU.Save
                (
                    fluxoCaixaVM.IDFluxoCaixa,
                    fluxoCaixaVM.DataLancamento,
                    fluxoCaixaVM.TipoLancamento,
                    OrigemFluxoCaixaEnum.FluxoCaixa,
                    0,
                    fluxoCaixaVM.Valor,
                    fluxoCaixaVM.Observacao
               );

            return Ok();
        }

        [HttpGet]
        [Route("fluxoCaixaImprimir/{idFluxoCaixa}")]
        public IActionResult FluxoCaixaImprimir(int idFluxoCaixa)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.FluxoCaixaImprimir(idFluxoCaixa, caminhoTemplate);
            var nomeArquivo = $"FluxoVenda_{idFluxoCaixa.ToString("00000")}.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Fluxo de Caixa
    }
}