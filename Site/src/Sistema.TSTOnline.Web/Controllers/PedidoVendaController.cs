using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.PedidoVenda;
using Sistema.TSTOnline.Web.Models.PedidoVenda;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using System.Collections.Generic;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain;
using Sistema.TSTOnline.Domain.Services.Fluxo;
using Sistema.TSTOnline.Domain.Services.Usuario;
using Sistema.TSTOnline.Domain.Services.Template;
using Microsoft.Extensions.Configuration;
using System;
using Sistema.TSTOnline.Domain.Services.Cadastros;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class PedidoVendaController : Controller
    {
        #region Variables

        private readonly IRepository<PedidoVendaEN> _pedidoVendaRepository;
        private readonly PedidoVendaBU _pedidoVendaBU;
        private readonly IRepository<PedidoVendaGrid> _listPedidoVendaRepository;
        private readonly FluxoBU _fluxoBU;

        private readonly IRepository<PedidoVendaItemEN> _pedidoVendaItemRepository;

        private readonly IRepository<VendedorEN> _vendedorRepository;
        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly EmpresaBU _empresaBU;
        private readonly IRepository<ProdutoEN> _produtoRepository;

        private readonly IConfiguration _configuration;

        private readonly TemplateBU _templateBU;

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private int idUser => _usuarioService.GetUserId();

        #endregion Variables

        #region Constructor

        public PedidoVendaController(
                IRepository<PedidoVendaEN> pedidoVendaRepository, PedidoVendaBU pedidoVendaBU,
                IRepository<PedidoVendaGrid> listPedidoVendaRepository,
                IRepository<PedidoVendaItemEN> pedidoVendaItemRepository,
                IRepository<VendedorEN> vendedorRepository,
                IRepository<EmpresaEN> empresaRepository,
                EmpresaBU empresaBU,
                IRepository<ProdutoEN> produtoRepository,
                FluxoBU fluxoBU,
                IConfiguration configuration,
                TemplateBU templateBU,
                UsuarioService usuarioService
            )
        {
            _pedidoVendaRepository = pedidoVendaRepository;
            _pedidoVendaBU = pedidoVendaBU;
            _listPedidoVendaRepository = listPedidoVendaRepository;

            _pedidoVendaItemRepository = pedidoVendaItemRepository;

            _vendedorRepository = vendedorRepository;

            _empresaRepository = empresaRepository;
            _empresaBU = empresaBU;

            _produtoRepository = produtoRepository;

            _fluxoBU = fluxoBU;

            _configuration = configuration;

            _templateBU = templateBU;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Pedido de Venda

        [HttpGet]
        [Route("pedidoVenda")]
        public IActionResult PedidoVenda(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("pedidoVendaAddEdit/{idPedido?}")]
        public IActionResult PedidoVendaAddEdit(int? idPedido)
        {
            if (idPedido != null)
            {
                var pedidoVenda = _pedidoVendaRepository.GetByID(idPedido ?? 0);

                var empresa = _empresaRepository.GetByID(pedidoVenda.IDEmpresa);

                var pedidoVendaVM = new PedidoVendaVM()
                {
                    IDPedido = pedidoVenda.IDPedido,
                    DataCadastro = pedidoVenda.DataCadastro,
                    DataVenda = pedidoVenda.DataVenda,
                    Status = pedidoVenda.Status,
                    IDVendedor = pedidoVenda.IDVendedor,
                    VendedorNome = _vendedorRepository.GetByID(pedidoVenda.IDVendedor)?.Nome ?? string.Empty,
                    IDEmpresa = pedidoVenda.IDEmpresa,
                    TipoPagamento = pedidoVenda.TipoPagamento,
                    QtdeParcelas = pedidoVenda.QtdeParcelas,
                    Observacao = pedidoVenda.Observacao,
                    RazaoSocial = empresa.RazaoSocial,
                    ResponsavelEmpresaNome = empresa.NomeRespEmpresa,
                    ResponsavelEmpresaCPF = empresa.CPFResponsavel,
                    ResponsavelEmpresaTelefone = empresa.TelResponsavel,
                    ResponsavelEmpresaNIT = empresa.NitResponsavel,
                    ResponsavelEmpresaEmail = empresa.EmailResponsavel,
                };

                return View(pedidoVendaVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listPedidosVenda")]
        public JsonResult ListPedidoVendas()
        {
            string SQL = $@"select
                                ped.idpedido        as id,
                                ped.idpedido        as idPedido,
                                ped.datavenda       as DataVenda,
                                emp.razaosocial     as razaoSocial,
                                ven.nome            as vendedorNome,
                                ped.tipopagamento   as tipoPagamento,
                                (select 
                                   sum(qtde * valor) 
                                  from tbpedidovendaitem 
                                 where idpedido = ped.idpedido) 
                                                    as valorTotal,
                                ped.status          as Status

                              from tbpedidovenda ped
                             inner join tbcadempresas emp on ped.idempresa = emp.idempresa
                             inner join tbcadvendedor ven on ped.idvendedor = ven.idvendedor
                             where ped.idcompany = {idCompany}";

            var listPedidosVenda = _listPedidoVendaRepository.FromSql(SQL).OrderByDescending(e => e.IDPedido).ToList();

            return Json(listPedidosVenda.ToList());
        }

        [HttpPost]
        [Route("pedidoVendaCreateOrUpdate")]
        public IActionResult PedidoVendaCreateOrUpdate([FromBody] PedidoVendaVM pedidoVendaVM)
        {
            if (pedidoVendaVM != null && pedidoVendaVM.PedidoVendaItens.Count > 0)
            {
                var status = PedidoVendaStatusEnum.Aberto;

                var listPedidoVendaItens = pedidoVendaVM.PedidoVendaItens.Select(
                    c => new PedidoVendaItemEN
                    {
                        IDPedidoItem = 0,
                        IDPedido = 0,
                        IDProduto = c.IDProduto,
                        Item = 0,
                        Qtde = c.Qtde,
                        Valor = c.Valor
                    });

                if (pedidoVendaVM.VendaExpress)
                {
                    var cpfCnpj = pedidoVendaVM.TipoPessoa == TipoPessoa.Fisica ? pedidoVendaVM.CPF : pedidoVendaVM.CNPJ;

                    pedidoVendaVM.IDEmpresa = _empresaBU.Save
                    (
                        idCompany,
                        idUser,
                        cpfCnpj,
                        pedidoVendaVM.NomeOuRazaoSocial,
                        pedidoVendaVM.NomeOuRazaoSocial,
                        pedidoVendaVM.CEP,
                        pedidoVendaVM.Endereco,
                        pedidoVendaVM.Numero,
                        pedidoVendaVM.Complemento,
                        pedidoVendaVM.Bairro,
                        pedidoVendaVM.Cidade,
                        pedidoVendaVM.UF
                    );
                }

                _pedidoVendaBU.Save
                (
                    pedidoVendaVM.IDPedido,
                    idCompany,
                    idUser,
                    pedidoVendaVM.DataVenda,
                    status,
                    pedidoVendaVM.IDUsuario,
                    pedidoVendaVM.IDVendedor,
                    pedidoVendaVM.IDEmpresa,
                    pedidoVendaVM.TipoPagamento,
                    pedidoVendaVM.QtdeParcelas,
                    pedidoVendaVM.Observacao,
                    listPedidoVendaItens.ToList()
                );

                return Ok();
            }
            else
            {
                throw new DomainException("É necessário informar pelo menos 1 item.");
            }
        }

        [HttpPut]
        [Route("alterarStatus/{id}/{status}")]
        public IActionResult PedidoVendaAlterarStatus(int id, PedidoVendaStatusEnum Status)
        {
            _fluxoBU.FluxoPedido(id, Status);

            return Ok();
        }

        [HttpGet]
        [Route("imprimir/{idPedido}")]
        public IActionResult OrdemServicoImprimir(int idPedido)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.PedidoVendaImprimir(idPedido, caminhoTemplate);
            var nomeArquivo = $"PedidoVenda_{idPedido.ToString("00000")}.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        #endregion Pedido de Venda

        #region Pedido de Venda Itens

        private List<PedidoVendaItemVM> GetPedidoVendaItens(int IDPedido)
        {
            var listPedidoVendaItem = _pedidoVendaItemRepository.Where(obj => obj.IDPedido == IDPedido);

            var pedidoVendaItemVM = listPedidoVendaItem.Select(
                c => new PedidoVendaItemVM
                {
                    IDPedidoItem = c.IDPedidoItem,
                    IDPedido = c.IDPedido,
                    Item = c.Item,
                    IDProduto = c.IDProduto,
                    ProdutoNome = _produtoRepository.GetByID(c.IDProduto)?.Nome ?? string.Empty,
                    Qtde = c.Qtde,
                    Valor = c.Valor
                });

            return pedidoVendaItemVM.ToList();
        }

        [HttpGet]
        [Route("listPedidosVendaItens/{idPedidoVenda}")]
        public JsonResult ListPedidoVendaItens(int IDPedidoVenda)
        {
            return Json(GetPedidoVendaItens(IDPedidoVenda));
        }

        #endregion Pedido de Venda Itens
    }
}