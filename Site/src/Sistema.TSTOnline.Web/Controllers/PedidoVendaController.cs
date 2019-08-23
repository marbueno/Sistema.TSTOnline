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

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class PedidoVendaController : Controller
    {
        #region Variables

        private readonly IRepository<PedidoVendaEN> _pedidoVendaRepository;
        private readonly PedidoVendaBU _pedidoVendaBU;

        private readonly IRepository<PedidoVendaItemEN> _pedidoVendaItemRepository;
        private readonly PedidoVendaItemBU _pedidoVendaItemBU;

        private readonly IRepository<VendedorEN> _vendedorRepository;
        private readonly IRepository<ProdutoEN> _produtoRepository;

        #endregion Variables

        #region Constructor

        public PedidoVendaController(
                IRepository<PedidoVendaEN> pedidoVendaRepository, PedidoVendaBU pedidoVendaBU,
                IRepository<PedidoVendaItemEN> pedidoVendaItemRepository, PedidoVendaItemBU pedidoVendaItemBU,
                IRepository<VendedorEN> vendedorRepository,
                IRepository<ProdutoEN> produtoRepository
            )
        {
            _pedidoVendaRepository = pedidoVendaRepository;
            _pedidoVendaBU = pedidoVendaBU;

            _pedidoVendaItemRepository = pedidoVendaItemRepository;
            _pedidoVendaItemBU = pedidoVendaItemBU;

            _vendedorRepository = vendedorRepository;

            _produtoRepository = produtoRepository;
        }

        #endregion Constructor

        #region Pedido de Venda

        [HttpGet]
        [Route("pedidoVenda")]
        public IActionResult PedidoVenda()
        {
            return View();
        }

        [HttpGet]
        [Route("pedidoVendaAddEdit/{idPedido?}")]
        public IActionResult PedidoVendaAddEdit(int? idPedido)
        {
            if (idPedido != null)
            {
                var pedidoVenda = _pedidoVendaRepository.GetByID(idPedido ?? 0);

                var pedidoVendaVM = new PedidoVendaVM()
                {
                    IDPedido = pedidoVenda.IDPedido,
                    DataCadastro = pedidoVenda.DataCadastro,
                    DataVenda = pedidoVenda.DataVenda,
                    Status = pedidoVenda.Status,
                    IDVendedor = pedidoVenda.IDVendedor,
                    VendedorNome = _vendedorRepository.GetByID(pedidoVenda.IDVendedor).Nome,
                };

                return View(pedidoVendaVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listPedidosVenda")]
        public JsonResult ListPedidoVendas()
        {
            var listPedidoVendas = _pedidoVendaRepository.All();
            var pedidoVendaVM = listPedidoVendas.Select(
                c => new PedidoVendaVM
                {
                    IDPedido = c.IDPedido,
                    DataCadastro = c.DataCadastro,
                    DataVenda = c.DataVenda,
                    Status = c.Status,
                    IDVendedor = c.IDVendedor,
                    VendedorNome = _vendedorRepository.GetByID(c.IDVendedor).Nome
                });

            return Json(pedidoVendaVM.ToList());
        }

        [HttpPost]
        [Route("pedidoVendaCreateOrUpdate")]
        public IActionResult PedidoVendaCreateOrUpdate([FromBody] PedidoVendaVM pedidoVendaVM)
        {
            if (pedidoVendaVM != null && pedidoVendaVM.PedidoVendaItens.Count > 0)
            {
                var status = PedidoVendaStatusEnum.Aberto;

                var idPedidoVenda = _pedidoVendaBU.Save
                    (
                        pedidoVendaVM.IDPedido,
                        pedidoVendaVM.DataVenda,
                        status,
                        pedidoVendaVM.IDUsuario,
                        pedidoVendaVM.IDVendedor
                   );

                _pedidoVendaItemBU.RemoveAllItems(idPedidoVenda);

                int item = 1;
                foreach (var itemServico in pedidoVendaVM.PedidoVendaItens)
                {
                    _pedidoVendaItemBU.Save(itemServico.IDPedidoItem, idPedidoVenda, item, itemServico.IDProduto, itemServico.Qtde, itemServico.Valor);
                    item++;
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("alterarStatus/{id}/{status}")]
        public IActionResult PedidoVendaAlterarStatus(int id, PedidoVendaStatusEnum Status)
        {
            _pedidoVendaBU.UpdateStatus(id, Status);

            return Ok();
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
                    ProdutoNome = _produtoRepository.GetByID(c.IDProduto).Nome,
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