using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Services.Usuario;
using Sistema.TSTOnline.Domain.Services.Template;
using Microsoft.Extensions.Configuration;
using System;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class RelatoriosController : Controller
    {
        #region Variables

        private readonly IConfiguration _configuration;

        private readonly TemplateBU _templateBU;

        private readonly UsuarioService _usuarioService;

        #endregion Variables

        #region Constructor

        public RelatoriosController(
                IConfiguration configuration,
                TemplateBU templateBU,
                UsuarioService usuarioService
            )
        {
            _configuration = configuration;

            _templateBU = templateBU;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Vendas Por Vendedor

        [HttpGet]
        [Route("vendasPorVendedor")]
        public IActionResult VendasPorVendedor(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("vendasPorVendedorImprimir/{idVendedor}/{dataInicial}/{dataFinal}")]
        public IActionResult VendasPorVendedorImprimir(int idVendedor, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.VendasPorVendedorImprimir(caminhoTemplate, idVendedor, dataInicial, dataFinal);
            var nomeArquivo = $"VendasPorVendedor.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Vendas Por Vendedor

        #region Vendas Por Cliente

        [HttpGet]
        [Route("vendasPorCliente")]
        public IActionResult VendasPorCliente(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("vendasPorClienteImprimir/{idEmpresa}/{dataInicial}/{dataFinal}")]
        public IActionResult VendasPorClienteImprimir(int idEmpresa, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.VendasPorClienteImprimir(caminhoTemplate, idEmpresa, dataInicial, dataFinal);
            var nomeArquivo = $"VendasPorCliente.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Vendas Por Cliente

        #region Vendas Detalhadas

        [HttpGet]
        [Route("vendasDetalhadas")]
        public IActionResult VendasDetalhadas(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("vendasDetalhadasImprimir/{idEmpresa}/{idVendedor}/{idStatus}/{dataInicial}/{dataFinal}")]
        public IActionResult VendasDetalhadasImprimir(int idEmpresa, int idVendedor, PedidoVendaStatusEnum idStatus, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.VendasDetalhadasImprimir(caminhoTemplate, idEmpresa, idVendedor, idStatus, dataInicial, dataFinal);
            var nomeArquivo = $"VendasDetalhadas.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Vendas Detalhadas

        #region Vendas Por Produto

        [HttpGet]
        [Route("vendasPorProduto")]
        public IActionResult VendasPorProduto(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("vendasPorProdutoImprimir/{idEmpresa}/{idVendedor}/{idStatus}/{dataInicial}/{dataFinal}")]
        public IActionResult VendasPorProdutoImprimir(int idEmpresa, int idVendedor, PedidoVendaStatusEnum idStatus, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.VendasPorProdutoImprimir(caminhoTemplate, idEmpresa, idVendedor, idStatus, dataInicial, dataFinal);
            var nomeArquivo = $"VendasPorProduto.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Vendas Por Produto
    }
}