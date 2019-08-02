using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.OrdemServico;
using Sistema.TSTOnline.Web.Models.OrdemServico;
using System.Linq;

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

        #endregion Variables

        #region Constructor

        public OrdemServicoController(
                IRepository<LocalServicoEN> localServicoRepository, LocalServicoBU localServicoBU,
                IRepository<TipoServicoEN> tipoServicoRepository, TipoServicoBU tipoServicoBU
            )
        {
            _localServicoRepository = localServicoRepository;
            _localServicoBU = localServicoBU;

            _tipoServicoRepository = tipoServicoRepository;
            _tipoServicoBU = tipoServicoBU;
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
    }
}