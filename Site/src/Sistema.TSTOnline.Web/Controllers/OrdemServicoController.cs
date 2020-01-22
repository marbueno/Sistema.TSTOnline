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
using Sistema.TSTOnline.Domain.Services.Usuario;
using Microsoft.Extensions.Configuration;
using Sistema.TSTOnline.Domain.Services.Cadastros;

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
        private readonly EmpresaBU _empresaBU;

        private readonly IRepository<AmbienteEN> _ambienteRepository;
        private readonly AmbienteBU _ambienteBU;

        private readonly IConfiguration _configuration;

        private readonly TemplateBU _templateBU;

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private int idUser => _usuarioService.GetUserId();

        #endregion Variables

        #region Constructor

        public OrdemServicoController(
                IRepository<LocalServicoEN> localServicoRepository, LocalServicoBU localServicoBU,
                IRepository<TipoServicoEN> tipoServicoRepository, TipoServicoBU tipoServicoBU,
                IRepository<OrdemServicoEN> ordemServicoRepository, OrdemServicoBU ordemServicoBU,
                IRepository<OrdemServicoItemEN> ordemServicoItemRepository, OrdemServicoItemBU ordemServicoItemBU,
                IRepository<ResponsavelEN> responsavelRepository,
                IRepository<EmpresaEN> empresaRepository, EmpresaBU empresaBU,
                IRepository<AmbienteEN> ambienteRepository, AmbienteBU ambienteBU,
                IConfiguration configuration,
                TemplateBU templateBU,
                UsuarioService usuarioService
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
            _empresaBU = empresaBU;

            _ambienteRepository = ambienteRepository;
            _ambienteBU = ambienteBU;

            _configuration = configuration;

            _templateBU = templateBU;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Locais de Serviço

        [HttpGet]
        [Route("localServico")]
        public IActionResult LocalServico(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
                    WhatsApp = localServico.WhatsApp,
                    Observacao = localServico.Observacao
                };

                return View(localServicoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listLocaisServicos")]
        public JsonResult ListLocaisServicos()
        {
            var listLocalServico = _localServicoRepository.Where(obj => obj.IDCompany == idCompany).ToList();
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
                    idCompany,
                    idUser,
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
                    localServicoVM.WhatsApp,
                    localServicoVM.Observacao
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
        public IActionResult TipoServico(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
            var listTipoServico = _tipoServicoRepository.Where(obj => obj.IDCompany == idCompany).ToList();
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
                    idCompany,
                    idUser,
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
        public IActionResult OrdemServico(int? idCompany, int? idUser)
        {
            _usuarioService.SetUserId(idCompany ?? 0, idUser ?? 0);
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
                    HorarioServico = ordemServico.HorarioServico,
                    Status = ordemServico.Status,
                    IDEmpresa = ordemServico.IDEmpresa,
                    RazaoSocial = _empresaRepository.GetByID(ordemServico.IDEmpresa).RazaoSocial,
                    IDResp = ordemServico.IDResp,
                    ResponsavelNome = _responsavelRepository.GetByID(ordemServico.IDResp)?.NomeResponsavel ?? string.Empty,
                    IDLocal = ordemServico.IDLocal,
                    NomeContato = ordemServico.NomeContato,
                    Telefone = ordemServico.Telefone,
                    WhatsApp = ordemServico.WhatsApp,
                    LocalDescricao = _ambienteRepository.GetByID(ordemServico.IDLocal)?.NomeEstab ?? string.Empty,
                };

                return View(ordemServicoVM);
            }

            return View();
        }

        [HttpGet]
        [Route("listOrdemServicos")]
        public JsonResult ListOrdemServicos()
        {
            var listOrdemServico = _ordemServicoRepository.Where(obj => obj.IDCompany == idCompany).ToList();

            List<OrdemServicoVM> listOrdemServicoVM = new List<OrdemServicoVM>();

            foreach (var itemOS in listOrdemServico)
            {
                var empresa = _empresaRepository.GetByID(itemOS.IDEmpresa);
                var responsavel = _responsavelRepository.GetByID(itemOS.IDResp);
                var ambiente = _ambienteRepository.GetByID(itemOS.IDLocal);
                //var localServico = _localServicoRepository.GetByID(itemOS.IDLocal);

                OrdemServicoVM ordemServicoVM = new OrdemServicoVM()
                {
                    IDOrdemServico = itemOS.IDOrdemServico,
                    DataCadastro = itemOS.DataCadastro,
                    DataServico = itemOS.DataServico,
                    Status = itemOS.Status,
                    IDEmpresa = itemOS.IDEmpresa,
                    IDResp = itemOS.IDResp,
                    IDLocal = itemOS.IDLocal,
                    NomeContato = itemOS.NomeContato,
                    Telefone = itemOS.Telefone,
                    WhatsApp = itemOS.WhatsApp,
                };

                if (empresa != null)
                {
                    ordemServicoVM.RazaoSocial = empresa.RazaoSocial;
                }

                if (responsavel != null)
                {
                    ordemServicoVM.ResponsavelNome = responsavel.NomeResponsavel;
                }

                if (ambiente != null)
                {
                    ordemServicoVM.LocalDescricao = ambiente.NomeEstab;
                }

                listOrdemServicoVM.Add(ordemServicoVM);
            }

            return Json(listOrdemServicoVM.ToList());
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

                if (ordemServicoVM.OsExpress)
                {
                    var cpfCnpj = ordemServicoVM.TipoPessoa == TipoPessoa.Fisica ? ordemServicoVM.CPF : ordemServicoVM.CNPJ;

                    ordemServicoVM.IDEmpresa = _empresaBU.Save
                    (
                        idCompany,
                        idUser,
                        cpfCnpj,
                        ordemServicoVM.NomeOuRazaoSocial,
                        ordemServicoVM.NomeOuRazaoSocial,
                        ordemServicoVM.CEP,
                        ordemServicoVM.Endereco,
                        ordemServicoVM.Numero,
                        ordemServicoVM.Complemento,
                        ordemServicoVM.Bairro,
                        ordemServicoVM.Cidade,
                        ordemServicoVM.UF,
                        ordemServicoVM.TelefoneOE,
                        ordemServicoVM.WhatsAppOE
                    );

                    ordemServicoVM.IDLocal = _ambienteBU.Save
                    (
                        idCompany,
                        idUser,
                        ordemServicoVM.NomeEstab,
                        ordemServicoVM.CepEstab,
                        ordemServicoVM.EnderecoEstab,
                        ordemServicoVM.NumeroEstab,
                        ordemServicoVM.ComplementoEstab,
                        ordemServicoVM.BairroEstab,
                        ordemServicoVM.CidadeEstab,
                        ordemServicoVM.UFEstab
                    );
                }

                var idOrdemServico = _ordemServicoBU.Save
                    (
                        ordemServicoVM.IDOrdemServico,
                        idCompany,
                        idUser,
                        ordemServicoVM.DataServico,
                        ordemServicoVM.HorarioServico,
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
        [Route("imprimir/{idServico}")]
        public IActionResult OrdemServicoImprimir(int idServico)
        {
            var caminhoTemplate = _configuration.GetSection("Environment:CaminhoTemplate").Value;

            var documento = _templateBU.OrdemServicoImprimir(idServico, caminhoTemplate);
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
                    TipoServicoDescricao = _tipoServicoRepository.GetByID(c.IDTipoServico)?.Descricao ?? string.Empty,
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