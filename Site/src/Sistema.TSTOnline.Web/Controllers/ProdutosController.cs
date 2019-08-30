using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Produtos;
using Sistema.TSTOnline.Web.Models.Produtos;
using System.Linq;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class ProdutosController : Controller
    {
        #region Variables

        private readonly IRepository<CategoriaEN> _categoriaRepository;
        private readonly CategoriaBU _categoriaBU;

        private readonly IRepository<SubCategoriaEN> _subCategoriaRepository;
        private readonly SubCategoriaBU _subCategoriaBU;

        private readonly IRepository<ProdutoEN> _produtoRepository;
        private readonly ProdutoBU _produtoBU;

        private readonly IRepository<FornecedorEN> _fornecedorRepository;

        private readonly EstoqueBU _estoqueBU;

        #endregion Variables

        #region Constructor

        public ProdutosController(
                IRepository<CategoriaEN> categoriaRepository, CategoriaBU categoriaBU,
                IRepository<SubCategoriaEN> subCategoriaRepository, SubCategoriaBU subCategoriaBU,
                IRepository<ProdutoEN> produtoRepository, ProdutoBU produtoBU,
                IRepository<FornecedorEN> fornecedorRepository,
                EstoqueBU estoqueBU
            )
        {
            _categoriaRepository = categoriaRepository;
            _categoriaBU = categoriaBU;

            _subCategoriaRepository = subCategoriaRepository;
            _subCategoriaBU = subCategoriaBU;

            _produtoRepository = produtoRepository;
            _produtoBU = produtoBU;

            _fornecedorRepository = fornecedorRepository;

            _estoqueBU = estoqueBU;
        }

        #endregion Constructor

        #region Categorias

        [HttpGet]
        [Route("categoria")]
        public IActionResult Categoria()
        {
            return View();
        }

        [HttpGet]
        [Route("categoriaAddEdit/{idCategoria?}")]
        public IActionResult CategoriaAddEdit(int? idCategoria)
        {
            if (idCategoria != null)
            {
                var categoria = _categoriaRepository.GetByID(idCategoria ?? 0);

                var categoriaVM = new CategoriaVM()
                {
                    IDCategoria = categoria.IDCategoria,
                    Descricao = categoria.Descricao
                };

                return View(categoriaVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listCategorias")]
        public JsonResult ListCategorias()
        {
            var listCategoria = _categoriaRepository.All();
            var categoriaVM = listCategoria.Select(
                c => new CategoriaVM
                {
                    IDCategoria = c.IDCategoria,
                    Descricao = c.Descricao
                });

            return Json(categoriaVM.ToList());
        }

        [HttpPost]
        [Route("categoriaCreateOrUpdate")]
        public IActionResult CategoriaCreateOrUpdate(CategoriaVM categoriaVM)
        {
            _categoriaBU.Save
                (
                    categoriaVM.IDCategoria,
                    categoriaVM.Descricao
               );

            return Ok();
        }

        [HttpDelete]
        [Route("categoriaDelete/{id}")]
        public IActionResult CategoriaDelete(int id)
        {
            _categoriaRepository.Delete(id);

            return Ok();
        }

        #endregion Categorias

        #region Sub Categorias

        [HttpGet]
        [Route("subCategoria")]
        public IActionResult SubCategoria()
        {
            return View();
        }

        [HttpGet]
        [Route("subCategoriaAddEdit/{idSubCategoria?}")]
        public IActionResult SubCategoriaAddEdit(int? idSubCategoria)
        {
            if (idSubCategoria != null)
            {
                var subCategoria = _subCategoriaRepository.GetByID(idSubCategoria ?? 0);

                var subCategoriaVM = new SubCategoriaVM()
                {
                    IDSubCategoria = subCategoria.IDSubCategoria,
                    IDCategoria = subCategoria.IDCategoria,
                    Descricao = subCategoria.Descricao
                };

                return View(subCategoriaVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listSubCategorias")]
        public JsonResult ListSubCategorias()
        {
            var listSubCategoria = _subCategoriaRepository.All();
            var subCategoriaVM = listSubCategoria.Select(
                c => new SubCategoriaVM
                {
                    IDSubCategoria = c.IDSubCategoria,
                    IDCategoria = c.IDCategoria,
                    CategoriaDescricao = _categoriaRepository.GetByID(c.IDCategoria).Descricao,
                    Descricao = c.Descricao
                });

            return Json(subCategoriaVM.ToList());
        }

        [HttpPost]
        [Route("subCategoriaCreateOrUpdate")]
        public IActionResult SubCategoriaCreateOrUpdate(SubCategoriaVM subCategoriaVM)
        {
            _subCategoriaBU.Save
                (
                    subCategoriaVM.IDSubCategoria,
                    subCategoriaVM.IDCategoria,
                    subCategoriaVM.Descricao
               );

            return Ok();
        }

        [HttpDelete]
        [Route("subCategoriaDelete/{id}")]
        public IActionResult SubCategoriaDelete(int id)
        {
            _subCategoriaRepository.Delete(id);

            return Ok();
        }

        #endregion Sub Categorias

        #region Produtos

        [HttpGet]
        [Route("produto")]
        public IActionResult Produto()
        {
            return View();
        }

        [HttpGet]
        [Route("produtoAddEdit/{idProduto?}")]
        public IActionResult ProdutoAddEdit(int? idProduto)
        {
            if (idProduto != null)
            {
                var produto = _produtoRepository.GetByID(idProduto ?? 0);

                var produtoVM = new ProdutoVM()
                {
                    IDProduto = produto.IDProduto,
                    SKU = produto.SKU,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    IDFornecedor = produto.IDFornecedor,
                    FornecedorRazaoSocial = _fornecedorRepository.GetByID(produto.IDFornecedor).RazaoSocial,
                    IDCategoria = produto.IDCategoria,
                    CategoriaDescricao = _categoriaRepository.GetByID(produto.IDCategoria).Descricao,
                    IDSubCategoria = produto.IDSubCategoria,
                    SubCategoriaDescricao = _subCategoriaRepository.GetByID(produto.IDSubCategoria).Descricao,
                    Preco = produto.Preco
                };

                return View(produtoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listProdutos")]
        public JsonResult ListProdutos()
        {
            var listProdutos = _produtoRepository.All();
            var produtoVM = listProdutos.Select(
                c => new ProdutoVM
                {
                    IDProduto = c.IDProduto,
                    SKU = c.SKU,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    IDFornecedor = c.IDFornecedor,
                    FornecedorRazaoSocial = _fornecedorRepository.GetByID(c.IDFornecedor).RazaoSocial,
                    IDCategoria = c.IDCategoria,
                    CategoriaDescricao = _categoriaRepository.GetByID(c.IDCategoria).Descricao,
                    IDSubCategoria = c.IDSubCategoria,
                    SubCategoriaDescricao = _subCategoriaRepository.GetByID(c.IDSubCategoria).Descricao,
                    Preco = c.Preco
                });

            return Json(produtoVM.ToList());
        }

        [HttpPost]
        [Route("produtoCreateOrUpdate")]
        public IActionResult ProdutoCreateOrUpdate(ProdutoVM produtoVM)
        {
            _produtoBU.Save
                (
                    produtoVM.IDProduto,
                    produtoVM.SKU,
                    produtoVM.Nome,
                    produtoVM.Descricao,
                    produtoVM.IDFornecedor,
                    produtoVM.IDCategoria,
                    produtoVM.IDSubCategoria,
                    produtoVM.Preco
               );

            return Ok();
        }

        [HttpDelete]
        [Route("produtoDelete/{id}")]
        public IActionResult ProdutoDelete(int id)
        {
            _produtoRepository.Delete(id);

            return Ok();
        }

        #endregion Produtos
    }
}