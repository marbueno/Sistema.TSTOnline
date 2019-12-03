using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Produtos;
using Sistema.TSTOnline.Web.Models.Produtos;
using System.Linq;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Services.Usuario;
using System.Collections.Generic;

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

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private int idUser => _usuarioService.GetUserId();

        #endregion Variables

        #region Constructor

        public ProdutosController(
                IRepository<CategoriaEN> categoriaRepository, CategoriaBU categoriaBU,
                IRepository<SubCategoriaEN> subCategoriaRepository, SubCategoriaBU subCategoriaBU,
                IRepository<ProdutoEN> produtoRepository, ProdutoBU produtoBU,
                IRepository<FornecedorEN> fornecedorRepository,
                UsuarioService usuarioService
            )
        {
            _categoriaRepository = categoriaRepository;
            _categoriaBU = categoriaBU;

            _subCategoriaRepository = subCategoriaRepository;
            _subCategoriaBU = subCategoriaBU;

            _produtoRepository = produtoRepository;
            _produtoBU = produtoBU;

            _fornecedorRepository = fornecedorRepository;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Categorias

        [HttpGet]
        [Route("categoria")]
        public IActionResult Categoria(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
            var listCategoria = _categoriaRepository.Where(obj => obj.IDCompany == idCompany).ToList();
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
                    idCompany,
                    idUser,
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
        public IActionResult SubCategoria(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
            var listSubCategoria = _subCategoriaRepository.Where(obj => obj.IDCompany == idCompany).ToList();
            var subCategoriaVM = listSubCategoria.Select(
                c => new SubCategoriaVM
                {
                    IDSubCategoria = c.IDSubCategoria,
                    IDCategoria = c.IDCategoria,
                    CategoriaDescricao = _categoriaRepository.GetByID(c.IDCategoria)?.Descricao ?? string.Empty,
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
                    idCompany,
                    idUser,
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
        public IActionResult Produto(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
                    FornecedorRazaoSocial = _fornecedorRepository.GetByID(produto.IDFornecedor)?.RazaoSocial ?? string.Empty,
                    IDCategoria = produto.IDCategoria,
                    CategoriaDescricao = _categoriaRepository.GetByID(produto.IDCategoria)?.Descricao ?? string.Empty,
                    IDSubCategoria = produto.IDSubCategoria,
                    SubCategoriaDescricao = _subCategoriaRepository.GetByID(produto.IDSubCategoria)?.Descricao ?? string.Empty,
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
            var listProdutos = _produtoRepository.Where(obj => obj.IDCompany == idCompany).ToList();

            List<ProdutoVM> listProdutoVM = new List<ProdutoVM>();

            foreach (var itemProduto in listProdutos)
            {
                var fornecedor = _fornecedorRepository.GetByID(itemProduto.IDFornecedor);
                var categoria = _categoriaRepository.GetByID(itemProduto.IDCategoria);
                var subCategoria = _subCategoriaRepository.GetByID(itemProduto.IDSubCategoria);

                ProdutoVM produtoVM = new ProdutoVM()
                {
                    IDProduto = itemProduto.IDProduto,
                    //SKU = itemProduto.SKU,
                    SKU = string.Empty,
                    Nome = itemProduto.Nome,
                    Descricao = itemProduto.Descricao,
                    IDFornecedor = itemProduto.IDFornecedor,
                    FornecedorRazaoSocial = string.Empty,
                    IDCategoria = itemProduto.IDCategoria,
                    CategoriaDescricao = string.Empty,
                    IDSubCategoria = itemProduto.IDSubCategoria,
                    SubCategoriaDescricao = string.Empty,
                    Preco = itemProduto.Preco
                };

                if (fornecedor != null)
                {
                    produtoVM.FornecedorRazaoSocial = fornecedor.RazaoSocial;
                }

                if (categoria != null)
                {
                    produtoVM.CategoriaDescricao = categoria.Descricao;
                }

                if (subCategoria != null)
                {
                    produtoVM.SubCategoriaDescricao = subCategoria.Descricao;
                }

                listProdutoVM.Add(produtoVM);
            }

            return Json(listProdutoVM.ToList());
        }

        [HttpPost]
        [Route("produtoCreateOrUpdate")]
        public IActionResult ProdutoCreateOrUpdate([FromBody] ProdutoVM produtoVM)
        {
            _produtoBU.Save
                (
                    produtoVM.IDProduto,
                    idCompany,
                    idUser,
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