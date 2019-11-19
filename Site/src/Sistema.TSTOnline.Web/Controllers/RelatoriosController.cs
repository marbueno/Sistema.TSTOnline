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

        #region Movimentação de Estoque

        [HttpGet]
        [Route("movimentacaoEstoque")]
        public IActionResult MovimentacaoEstoque(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("movimentacaoEstoqueImprimir/{idOrigem}/{idTipo}/{idProduto}/{dataInicial}/{dataFinal}")]
        public IActionResult MovimentacaoEstoqueImprimir(OrigemMovimentoEstoqueEnum idOrigem, TipoMovimentoEstoqueEnum idTipo, int idProduto, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.MovimentacaoEstoqueImprimir(caminhoTemplate, idOrigem, idTipo, idProduto, dataInicial, dataFinal);
            var nomeArquivo = $"MovimentacaoEstoque.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Movimentação de Estoque

        #region Ordem Serviço Por Técnico

        [HttpGet]
        [Route("ordemServicoPorTecnico")]
        public IActionResult OrdemServicoPorTecnico(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("ordemServicoPorTecnicoImprimir/{idResp}/{dataInicial}/{dataFinal}")]
        public IActionResult OrdemServicoPorTecnicoImprimir(int idResp, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.OrdemServicoPorTecnicoImprimir(caminhoTemplate, idResp, dataInicial, dataFinal);
            var nomeArquivo = $"OrdemServicoPorTecnico.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Ordem Serviço Por Técnico

        #region Ordem Serviço Por Cliente

        [HttpGet]
        [Route("ordemServicoPorCliente")]
        public IActionResult OrdemServicoPorCliente(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("ordemServicoPorClienteImprimir/{idEmpresa}/{dataInicial}/{dataFinal}")]
        public IActionResult OrdemServicoPorClienteImprimir(int idEmpresa, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.OrdemServicoPorClienteImprimir(caminhoTemplate, idEmpresa, dataInicial, dataFinal);
            var nomeArquivo = $"OrdemServicoPorCliente.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Ordem Serviço Por Cliente

        #region Ordem de Serviço Detalhada

        [HttpGet]
        [Route("ordemServicoDetalhada")]
        public IActionResult OrdemServicoDetalhada(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("ordemServicoDetalhadaImprimir/{idEmpresa}/{idResp}/{idStatus}/{dataInicial}/{dataFinal}")]
        public IActionResult OrdemServicoImprimir(int idEmpresa, int idResp, OrdemServicoStatusEnum idStatus, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.OrdemServicoDetalhadaImprimir(caminhoTemplate, idEmpresa, idResp, idStatus, dataInicial, dataFinal);
            var nomeArquivo = $"OrdemServicoDetalhada.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Ordem de Serviço Detalhada

        #region Ordem Serviço Por Tipo

        [HttpGet]
        [Route("ordemServicoPorTipo")]
        public IActionResult OrdemServicoPorTipo(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("ordemServicoPorTipoImprimir/{idEmpresa}/{idResp}/{idStatus}/{dataInicial}/{dataFinal}")]
        public IActionResult OrdemServicoPorTipoImprimir(int idEmpresa, int idResp, OrdemServicoStatusEnum idStatus, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.OrdemServicoPorTipoImprimir(caminhoTemplate, idEmpresa, idResp, idStatus, dataInicial, dataFinal);
            var nomeArquivo = $"OrdemServicoPorTipo.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Ordem Serviço Por Tipo

        #region Movimentação Financeira - Contas a Receber

        [HttpGet]
        [Route("movimentacaoFinanceiraContasReceber")]
        public IActionResult MovimentacaoFinanceiraContasReceber(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("movimentacaoFinanceiraContasReceberImprimir/{idEmpresa}/{idOrigem}/{idStatus}/{dataInicial}/{dataFinal}")]
        public IActionResult MovimentacaoFinanceiraContasReceberImprimir(int idEmpresa, OrigemContasReceberEnum idOrigem, ContasReceberStatusEnum idStatus, DateTime dataInicial, DateTime dataFinal)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.MovimentacaoFinanceiraContasReceberImprimir(caminhoTemplate, idEmpresa, idOrigem, idStatus, dataInicial, dataFinal);
            var nomeArquivo = $"MovimentacaoFinanceiraContasReceber.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Movimentação Financeira - Contas a Receber
    }
}