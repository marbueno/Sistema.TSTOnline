using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Web.Models.Estoque;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class EstoqueController : Controller
    {
        #region Variables

        private readonly IRepository<MovimentoEstoqueEN> _movimentoEstoqueRepository;
        private readonly MovimentoEstoqueBU _movimentoEstoqueBU;

        private readonly IRepository<EstoqueEN> _estoqueRepository;

        private readonly IRepository<ProdutoEN> _produtoRepository;

        #endregion Variables

        #region Constructor

        public EstoqueController(
                IRepository<MovimentoEstoqueEN> movimentoEstoqueRepository, MovimentoEstoqueBU movimentoEstoqueBU,
                IRepository<EstoqueEN> estoqueRepository, EstoqueBU estoqueBU,
                IRepository<ProdutoEN> produtoRepository
            )
        {
            _movimentoEstoqueRepository = movimentoEstoqueRepository;
            _movimentoEstoqueBU = movimentoEstoqueBU;

            _estoqueRepository = estoqueRepository;

            _produtoRepository = produtoRepository;
        }

        #endregion Constructor

        #region Movimentação de Estoque

        [HttpGet]
        [Route("movimentoEstoque")]
        public IActionResult MovimentoEstoque()
        {
            return View();
        }

        [HttpGet]
        [Route("movimentoEstoqueAddEdit/{idMovimentoEstoque?}")]
        public IActionResult MovimentoEstoqueAddEdit(int? idMovimentoEstoque)
        {
            if (idMovimentoEstoque != null)
            {
                var movimentoEstoque = _movimentoEstoqueRepository.GetByID(idMovimentoEstoque ?? 0);

                var movimentoEstoqueVM = new MovimentoEstoqueVM()
                {
                    IDMovimento = movimentoEstoque.IDMovimento,
                    DataMovimento = movimentoEstoque.DataMovimento,
                    Origem = movimentoEstoque.Origem,
                    Chave = movimentoEstoque.Chave,
                    IDProduto = movimentoEstoque.IDProduto,
                    Tipo = movimentoEstoque.Tipo,
                    Qtde = movimentoEstoque.Qtde,
                    Observacao = movimentoEstoque.Observacao
                };

                return View(movimentoEstoqueVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listMovimentoEstoque")]
        public JsonResult ListMovimentoEstoque()
        {
            var listMovimentoEstoque = _movimentoEstoqueRepository.All();
            var movimentoEstoqueVM = listMovimentoEstoque.Select(
                c => new MovimentoEstoqueVM
                {
                    IDMovimento = c.IDMovimento,
                    DataMovimento = c.DataMovimento,
                    Origem = c.Origem,
                    Chave = c.Chave,
                    IDProduto = c.IDProduto,
                    SKU = _produtoRepository.GetByID(c.IDProduto).SKU,
                    ProdutoNome = _produtoRepository.GetByID(c.IDProduto).Nome,
                    Tipo = c.Tipo,
                    Qtde = c.Qtde,
                    Observacao = c.Observacao
                });

            return Json(movimentoEstoqueVM.ToList());
        }

        [HttpPost]
        [Route("movimentoEstoqueCreateOrUpdate")]
        public IActionResult MovimentoEstoqueCreateOrUpdate(MovimentoEstoqueVM movimentoEstoqueVM)
        {
            _movimentoEstoqueBU.Save
                (
                    OrigemMovimentoEstoqueEnum.MovimentacaoEstoque,
                    0,
                    movimentoEstoqueVM.IDProduto,
                    movimentoEstoqueVM.Tipo,
                    movimentoEstoqueVM.Qtde,
                    movimentoEstoqueVM.Observacao
               );

            return Ok();
        }

        #endregion Movimentação de Estoque

        #region Estoques

        [HttpGet]
        [Route("estoque")]
        public IActionResult Estoque()
        {
            return View();
        }

        [HttpGet]
        [Route("listEstoques")]
        public JsonResult ListEstoques()
        {
            var listEstoques = _estoqueRepository.All();
            var estoqueVM = listEstoques.Select(
                c => new EstoqueVM
                {
                    IDProduto = c.IDProduto,
                    SKU = _produtoRepository.GetByID(c.IDProduto).SKU,
                    ProdutoNome = _produtoRepository.GetByID(c.IDProduto).Nome,
                    Qtde = c.Qtde
                });

            return Json(estoqueVM.ToList());
        }

        #endregion Estoques
    }
}