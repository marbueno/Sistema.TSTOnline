using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.OrdemServico;
using Sistema.TSTOnline.Web.Models.OrdemServico;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;
using Sistema.TSTOnline.Domain.Entities.Cadastros;

namespace Sistema.TSTOnline.Web.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class OrdemServicoController : Controller
    {
        #region Variables

        private readonly IRepository<LocalServicoEN> _localServicoRepository;
        private readonly LocalServicoBU _localServicoBU;

        private readonly IRepository<TipoServicoEN> _tipoServicoRepository;
        private readonly TipoServicoBU _tipoServicoBU;

        private readonly IRepository<OrdemServicoEN> _ordemServicoRepository;
        private readonly OrdemServicoBU _ordemServicoBU;

        private readonly IRepository<OrdemServicoItemEN> _ordemServicoItemRepository;
        private readonly OrdemServicoItemBU _ordemServicoItemBU;

        private readonly IRepository<ResponsavelEN> _responsavelRepository;

        #endregion Variables

        #region Constructor

        public OrdemServicoController(
                IRepository<LocalServicoEN> localServicoRepository, LocalServicoBU localServicoBU,
                IRepository<TipoServicoEN> tipoServicoRepository, TipoServicoBU tipoServicoBU,
                IRepository<OrdemServicoEN> ordemServicoRepository, OrdemServicoBU ordemServicoBU,
                IRepository<OrdemServicoItemEN> ordemServicoItemRepository, OrdemServicoItemBU ordemServicoItemBU,
                IRepository<ResponsavelEN> responsavelRepository
            )
        {
            _localServicoRepository = localServicoRepository;
            _localServicoBU = localServicoBU;

            _tipoServicoRepository = tipoServicoRepository;
            _tipoServicoBU = tipoServicoBU;

            _ordemServicoRepository = ordemServicoRepository;
            _ordemServicoBU = ordemServicoBU;

            _ordemServicoItemRepository = ordemServicoItemRepository;
            _ordemServicoItemBU = ordemServicoItemBU;

            _responsavelRepository = responsavelRepository;
        }

        #endregion Constructor

        #region Locais de Serviço

        [HttpGet]
        [Route("localServico")]
        public IActionResult LocalServico()
        {
            return View();
        }

        [HttpGet]
        [Route("localServicoAddEdit/{idLocalServico?}")]
        public IActionResult LocalServicoAddEdit(int? idLocalServico)
        {
            if (idLocalServico != null)
            {
                var localServico = _localServicoRepository.GetByID(idLocalServico ?? 0);

                var localServicoVM = new LocalServicoVM()
                {
                    IDLocal = localServico.IDLocal,
                    Nome = localServico.Nome,
                    CEP = localServico.CEP,
                    Endereco = localServico.Endereco,
                    Numero = localServico.Numero,
                    Complemento = localServico.Complemento,
                    Bairro = localServico.Bairro,
                    Cidade = localServico.Cidade,
                    UF = localServico.UF
                };

                return View(localServicoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listLocaisServicos")]
        public JsonResult ListLocaisServicos()
        {
            var listLocalServico = _localServicoRepository.All();
            var localServicoVM = listLocalServico.Select(
                c => new LocalServicoVM
                {
                    IDLocal = c.IDLocal,
                    Nome = c.Nome,
                    CEP = c.CEP,
                    Endereco = c.Endereco,
                    Numero = c.Numero,
                    Complemento = c.Complemento,
                    Bairro = c.Bairro,
                    Cidade = c.Cidade,
                    UF = c.UF
                });

            return Json(localServicoVM.ToList());
        }

        [HttpPost]
        [Route("localServicoCreateOrUpdate")]
        public IActionResult LocalServicoCreateOrUpdate(LocalServicoVM localServicoVM)
        {
            _localServicoBU.Save
                (
                    localServicoVM.IDLocal,
                    localServicoVM.Nome,
                    localServicoVM.CEP,
                    localServicoVM.Endereco,
                    localServicoVM.Numero,
                    localServicoVM.Complemento,
                    localServicoVM.Bairro,
                    localServicoVM.Cidade,
                    localServicoVM.UF
               );

            return Ok();
        }

        [HttpDelete]
        [Route("localServicoDelete/{id}")]
        public IActionResult LocalServicoDelete(int id)
        {
            _localServicoRepository.Delete(id);

            return Ok();
        }

        #endregion Locais de Serviço

        #region Tipos de Serviços

        [HttpGet]
        [Route("tipoServico")]
        public IActionResult TipoServico()
        {
            return View();
        }

        [HttpGet]
        [Route("tipoServicoAddEdit/{idTipoServico?}")]
        public IActionResult TipoServicoAddEdit(int? idTipoServico)
        {
            if (idTipoServico != null)
            {
                var tipoServico = _tipoServicoRepository.GetByID(idTipoServico ?? 0);

                var tipoServicoVM = new TipoServicoVM()
                {
                    IDTipoServico = tipoServico.IDTipoServico,
                    Descricao = tipoServico.Descricao
                };

                return View(tipoServicoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listTiposServicos")]
        public JsonResult ListTipoServicos()
        {
            var listTipoServico = _tipoServicoRepository.All();
            var tipoServicoVM = listTipoServico.Select(
                c => new TipoServicoVM
                {
                    IDTipoServico = c.IDTipoServico,
                    Descricao = c.Descricao
                });

            return Json(tipoServicoVM.ToList());
        }

        [HttpPost]
        [Route("tipoServicoCreateOrUpdate")]
        public IActionResult TipoServicoCreateOrUpdate(TipoServicoVM tipoServicoVM)
        {
            _tipoServicoBU.Save
                (
                    tipoServicoVM.IDTipoServico,
                    tipoServicoVM.Descricao
               );

            return Ok();
        }

        [HttpDelete]
        [Route("tipoServicoDelete/{id}")]
        public IActionResult TipoServicoDelete(int id)
        {
            _tipoServicoRepository.Delete(id);

            return Ok();
        }

        #endregion Tipos de Serviços

        #region Ordem de Serviço

        [HttpGet]
        [Route("ordemServico")]
        public IActionResult OrdemServico()
        {
            return View();
        }

        [HttpGet]
        [Route("ordemServicoAddEdit/{idServico?}")]
        public IActionResult OrdemServicoAddEdit(int? idServico)
        {
            if (idServico != null)
            {
                var ordemServico = _ordemServicoRepository.GetByID(idServico ?? 0);

                var ordemServicoVM = new OrdemServicoVM()
                {
                    IDOrdemServico = ordemServico.IDOrdemServico,
                    DataServico = ordemServico.DataServico,
                    Status = ordemServico.Status,
                    IDResp = ordemServico.IDResp,
                    IDLocal = ordemServico.IDLocal
                };

                return View(ordemServicoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listOrdemServicos")]
        public JsonResult ListOrdemServicos()
        {
            var listOrdemServico = _ordemServicoRepository.All();
            var ordemServicoVM = listOrdemServico.Select(
                c => new OrdemServicoVM
                {
                    IDOrdemServico = c.IDOrdemServico,
                    DataServico = c.DataServico,
                    Status = c.Status,
                    IDResp = c.IDResp,
                    ResponsavelNome = _responsavelRepository.GetByID(c.IDResp).NomeResponsavel,
                    IDLocal = c.IDLocal,
                    LocalDescricao = _localServicoRepository.GetByID(c.IDLocal).Nome
                });

            return Json(ordemServicoVM.ToList());
        }

        [HttpPost]
        [Route("ordemServicoCreateOrUpdate")]
        public IActionResult OrdemServicoCreateOrUpdate(OrdemServicoVM ordemServicoVM)
        {
            _ordemServicoBU.Save
                (
                    ordemServicoVM.IDOrdemServico,
                    ordemServicoVM.DataServico,
                    ordemServicoVM.Status,
                    ordemServicoVM.IDResp,
                    ordemServicoVM.IDLocal
               );

            return Ok();
        }

        [HttpPut]
        [Route("alterarStatus/{id}/{status}")]
        public IActionResult OrdemServicoDelete(int id, OrdemServicoStatusEnum Status)
        {
            _ordemServicoBU.UpdateStatus(id, Status);

            return Ok();
        }

        #endregion Ordem de Serviço

        #region Ordem de Serviço Itens

        [HttpGet]
        [Route("ordemServicoItem")]
        public IActionResult OrdemServicoItem()
        {
            return View();
        }

        [HttpGet]
        [Route("ordemServicoItemAddEdit/{idServico?}")]
        public IActionResult OrdemServicoItemAddEdit(int? idServicoItem)
        {
            if (idServicoItem != null)
            {
                var ordemServicoItem = _ordemServicoItemRepository.GetByID(idServicoItem ?? 0);

                var ordemServicoItemVM = new OrdemServicoItemVM()
                {
                    IDOrdemServicoItem = ordemServicoItem.IDOrdemServicoItem,
                    IDOrdemServico = ordemServicoItem.IDOrdemServico,
                    Item = ordemServicoItem.Item,
                    IDTipoServico = ordemServicoItem.IDTipoServico,
                    Concluido = ordemServicoItem.Concluido
                };

                return View(ordemServicoItemVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listOrdemServicoItens")]
        public JsonResult ListOrdemServicoItens()
        {
            var listOrdemServicoItem = _ordemServicoItemRepository.All();
            var ordemServicoItemVM = listOrdemServicoItem.Select(
                c => new OrdemServicoItemVM
                {
                    IDOrdemServicoItem = c.IDOrdemServicoItem,
                    IDOrdemServico = c.IDOrdemServico,
                    Item = c.Item,
                    IDTipoServico = c.IDTipoServico,
                    TipoServicoDescricao = _tipoServicoRepository.GetByID(c.IDTipoServico).Descricao,
                    Concluido = c.Concluido
                });

            return Json(ordemServicoItemVM.ToList());
        }

        [HttpPost]
        [Route("ordemServicoItemCreateOrUpdate")]
        public IActionResult OrdemServicoItemCreateOrUpdate(OrdemServicoItemVM ordemServicoItemVM)
        {
            _ordemServicoItemBU.Save
                (
                    ordemServicoItemVM.IDOrdemServicoItem,
                    ordemServicoItemVM.IDOrdemServico,
                    ordemServicoItemVM.Item,
                    ordemServicoItemVM.IDTipoServico,
                    ordemServicoItemVM.Observacao,
                    ordemServicoItemVM.Concluido
               );

            return Ok();
        }

        #endregion Ordem de Serviço Itens
    }
}