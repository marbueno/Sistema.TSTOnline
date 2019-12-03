using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Services.Usuario;
using Sistema.TSTOnline.Web.Models.Estoque;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;
using System.Collections.Generic;

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

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private int idUser => _usuarioService.GetUserId();

        #endregion Variables

        #region Constructor

        public EstoqueController(
                IRepository<MovimentoEstoqueEN> movimentoEstoqueRepository, MovimentoEstoqueBU movimentoEstoqueBU,
                IRepository<EstoqueEN> estoqueRepository, EstoqueBU estoqueBU,
                IRepository<ProdutoEN> produtoRepository,
                UsuarioService usuarioService
            )
        {
            _movimentoEstoqueRepository = movimentoEstoqueRepository;
            _movimentoEstoqueBU = movimentoEstoqueBU;

            _estoqueRepository = estoqueRepository;

            _produtoRepository = produtoRepository;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Movimentação de Estoque

        [HttpGet]
        [Route("movimentoEstoque")]
        public IActionResult MovimentoEstoque(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
            var listMovimentoEstoque = _movimentoEstoqueRepository.Where(obj => obj.IDCompany == idCompany).ToList();
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
                    idCompany,
                    idUser,
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
        public IActionResult Estoque(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
            return View();
        }

        [HttpGet]
        [Route("listEstoques")]
        public JsonResult ListEstoques()
        {
            var listEstoques = _estoqueRepository.Where(obj => obj.IDCompany == idCompany).ToList();

            List<EstoqueVM> listEstoqueVM = new List<EstoqueVM>();

            foreach (var itemEstoque in listEstoques)
            {
                var produto = _produtoRepository.GetByID(itemEstoque.IDProduto);

                if (produto != null) 
                {
                    EstoqueVM estoqueVM = new EstoqueVM() {
                        IDProduto = itemEstoque.IDProduto,
                        SKU = produto.SKU,
                        ProdutoNome = produto.Nome,
                        Qtde = itemEstoque.Qtde
                    };

                    listEstoqueVM.Add(estoqueVM);
                }
            }

            return Json(listEstoqueVM.ToList());
        }

        #endregion Estoques
    }
}