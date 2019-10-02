using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.OrdemServico;
using Sistema.TSTOnline.Web.Models.OrdemServico;
using System.Linq;
using Sistema.TSTOnline.Domain.Utils;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using System.Collections.Generic;
using System;
using Sistema.TSTOnline.Domain.Services.Template;

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

        private readonly IRepository<EmpresaEN> _empresaRepository;

        private readonly TemplateBU _templateBU;

        #endregion Variables

        #region Constructor

        public OrdemServicoController(
                IRepository<LocalServicoEN> localServicoRepository, LocalServicoBU localServicoBU,
                IRepository<TipoServicoEN> tipoServicoRepository, TipoServicoBU tipoServicoBU,
                IRepository<OrdemServicoEN> ordemServicoRepository, OrdemServicoBU ordemServicoBU,
                IRepository<OrdemServicoItemEN> ordemServicoItemRepository, OrdemServicoItemBU ordemServicoItemBU,
                IRepository<ResponsavelEN> responsavelRepository,
                IRepository<EmpresaEN> empresaRepository,
                TemplateBU templateBU
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

            _empresaRepository = empresaRepository;

            _templateBU = templateBU;
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
                    UF = localServico.UF,
                    NomeContato = localServico.NomeContato,
                    Telefone = localServico.Telefone,
                    WhatsApp = localServico.WhatsApp
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
                    UF = c.UF,
                    NomeContato = c.NomeContato,
                    Telefone = c.Telefone,
                    WhatsApp = c.WhatsApp
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
                    localServicoVM.UF,
                    localServicoVM.NomeContato,
                    localServicoVM.Telefone,
                    localServicoVM.WhatsApp
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
                    DataCadastro = ordemServico.DataCadastro,
                    DataServico = ordemServico.DataServico,
                    Status = ordemServico.Status,
                    IDEmpresa = ordemServico.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(ordemServico.IDEmpresa).RazaoSocial,
                    IDResp = ordemServico.IDResp,
                    ResponsavelNome = _responsavelRepository.GetByID(ordemServico.IDResp).NomeResponsavel,
                    IDLocal = ordemServico.IDLocal,
                    NomeContato = ordemServico.NomeContato,
                    Telefone = ordemServico.Telefone,
                    WhatsApp = ordemServico.WhatsApp,
                    LocalDescricao = _localServicoRepository.GetByID(ordemServico.IDLocal).Nome,
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
                    DataCadastro = c.DataCadastro,
                    DataServico = c.DataServico,
                    Status = c.Status,
                    IDEmpresa = c.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(c.IDEmpresa).RazaoSocial,
                    IDResp = c.IDResp,
                    ResponsavelNome = _responsavelRepository.GetByID(c.IDResp).NomeResponsavel,
                    IDLocal = c.IDLocal,
                    NomeContato = c.NomeContato,
                    Telefone = c.Telefone,
                    WhatsApp = c.WhatsApp,
                    LocalDescricao = _localServicoRepository.GetByID(c.IDLocal).Nome,
                });

            return Json(ordemServicoVM.ToList());
        }

        [HttpPost]
        [Route("ordemServicoCreateOrUpdate")]
        public IActionResult OrdemServicoCreateOrUpdate([FromBody] OrdemServicoVM ordemServicoVM)
        {
            if (ordemServicoVM != null && ordemServicoVM.OrdemServicoItens.Count > 0)
            {
                var qtdeItens = ordemServicoVM.OrdemServicoItens.Count();
                var qtdeItensConcluidos = ordemServicoVM.OrdemServicoItens.Where(itens => itens.Concluido == true).Count();
                var status = OrdemServicoStatusEnum.Iniciado;

                if (qtdeItensConcluidos == qtdeItens)
                    status = OrdemServicoStatusEnum.Concluido;

                else if (qtdeItensConcluidos > 0)
                    status = OrdemServicoStatusEnum.ParcialmenteConcluido;

                var idOrdemServico = _ordemServicoBU.Save
                    (
                        ordemServicoVM.IDOrdemServico,
                        ordemServicoVM.DataServico,
                        status,
                        ordemServicoVM.IDEmpresa,
                        ordemServicoVM.IDResp,
                        ordemServicoVM.IDLocal,
                        ordemServicoVM.NomeContato,
                        ordemServicoVM.Telefone,
                        ordemServicoVM.WhatsApp
                   );

                _ordemServicoItemBU.RemoveAllItems(idOrdemServico);

                int item = 1;
                foreach (var itemServico in ordemServicoVM.OrdemServicoItens)
                {
                    _ordemServicoItemBU.Save(itemServico.IDOrdemServicoItem, idOrdemServico, item, itemServico.IDTipoServico, itemServico.Observacao, itemServico.Concluido);
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
        public IActionResult OrdemServicoAlterarStatus(int id, OrdemServicoStatusEnum Status)
        {
            _ordemServicoBU.UpdateStatus(id, Status);

            return Ok();
        }

        [HttpGet]
        [Route("imprimir/{idServico?}")]
        public IActionResult OrdemServicoImprimir(int idServico)
        {
            var documento = _templateBU.OrdemServicoImprimir(idServico);
            var nomeArquivo = $"OS_{idServico.ToString("00000")}.pdf";

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = nomeArquivo
            };

            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());

            byte[] byteArray = Convert.FromBase64String(documento);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Pdf) ;
        }

        #endregion Ordem de Serviço

        #region Ordem de Serviço Itens

        private List<OrdemServicoItemVM> GetOrdemServicoItens(int IDOrdemServico)
        {
            var listOrdemServicoItem = _ordemServicoItemRepository.Where(obj => obj.IDOrdemServico == IDOrdemServico);

            var ordemServicoItemVM = listOrdemServicoItem.Select(
                c => new OrdemServicoItemVM
                {
                    IDOrdemServicoItem = c.IDOrdemServicoItem,
                    IDOrdemServico = c.IDOrdemServico,
                    Item = c.Item,
                    IDTipoServico = c.IDTipoServico,
                    TipoServicoDescricao = _tipoServicoRepository.GetByID(c.IDTipoServico).Descricao,
                    Observacao = c.Observacao,
                    Concluido = c.Concluido
                });

            return ordemServicoItemVM.ToList();
        }

        [HttpGet]
        [Route("listOrdemServicoItens/{idOrdemServico}")]
        public JsonResult ListOrdemServicoItens(int IDOrdemServico)
        {
            return Json(GetOrdemServicoItens(IDOrdemServico));
        }

        #endregion Ordem de Serviço Itens
    }
}