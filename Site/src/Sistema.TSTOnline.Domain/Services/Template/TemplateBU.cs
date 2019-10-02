using Sistema.Documentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Templates.OrdemServico;
using System;

namespace Sistema.TSTOnline.Domain.Services.Template
{
    public class TemplateBU
    {
        private readonly IRepository<OrdemServicoEN> _repositoryOrdemServico;
        private readonly IRepository<OrdemServicoItemEN> _repositoryOrdemServicoItem;
        private readonly IRepository<ResponsavelEN> _responsavelRepository;
        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly IRepository<LocalServicoEN> _localServicoRepository;
        private readonly IRepository<TipoServicoEN> _tipoServicoRepository;
        private readonly IDocumento _documentoService;

        public TemplateBU
            (
                IRepository<OrdemServicoEN> repositoryOrdemServico,
                IRepository<OrdemServicoItemEN> repositoryOrdemServicoItem,
                IRepository<ResponsavelEN> responsavelRepository,
                IRepository<EmpresaEN> empresaRepository,
                IRepository<LocalServicoEN> localServicoRepository,
                IRepository<TipoServicoEN> tipoServicoRepository,
                IDocumento documentoService
            )
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _repositoryOrdemServicoItem = repositoryOrdemServicoItem;
            _responsavelRepository = responsavelRepository;
            _empresaRepository = empresaRepository;
            _localServicoRepository = localServicoRepository;
            _tipoServicoRepository = tipoServicoRepository;
            _documentoService = documentoService;
        }

        public string OrdemServicoImprimir(int IDOrdemServico)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);
            var listOrdemServicoItem = _repositoryOrdemServicoItem.Where(obj => obj.IDOrdemServico == IDOrdemServico);
            LocalServicoEN localServivoEN = _localServicoRepository.GetByID(ordemServicoEN.IDLocal);

            OrdemServicoTemplate osTemplate = new OrdemServicoTemplate()
            {
                OrdemServicoNumero = ordemServicoEN.IDOrdemServico.ToString("000000"),
                DataInclusao = DateTime.Now.ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToString("HH:mm:sss"),
                OrdemServicoData = ordemServicoEN.DataServico.ToString("HH:mm:sss"),
                ClienteRazaoSocial = _empresaRepository.GetByID(ordemServicoEN.IDEmpresa).RazaoSocial,
                ResponsavelNome = _responsavelRepository.GetByID(ordemServicoEN.IDResp).NomeResponsavel,
                LocalNome = localServivoEN.Nome,
                LocalCEP = Sistema.Utils.Helper.FormatarCEP(localServivoEN.CEP),
                LocalEndereco = Sistema.Utils.Helper.FormatarCEP(localServivoEN.Endereco),
                LocalNumero = Sistema.Utils.Helper.FormatarCEP(localServivoEN.Numero),
                LocalComplemento = Sistema.Utils.Helper.FormatarCEP(localServivoEN.Complemento),
                LocalBairro = Sistema.Utils.Helper.FormatarCEP(localServivoEN.Bairro),
                LocalCidade = Sistema.Utils.Helper.FormatarCEP(localServivoEN.Cidade),
                ContatoNome = ordemServicoEN.NomeContato,
                ContatoTelefone = ordemServicoEN.Telefone,
                ContatoWhatsApp = ordemServicoEN.WhatsApp,

                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now),
            };

            var HTMLItens = "<table>";
            foreach (var itemOS in listOrdemServicoItem)
            {
                TipoServicoEN tipoServicoEN = _tipoServicoRepository.GetByID(itemOS.IDTipoServico);

                HTMLItens += $"  <tr>";
                HTMLItens += $"      <td style=\"font-weight: bold; width: 5%\"><span>Item: </span></td>";
                HTMLItens += $"      <td>{itemOS.Item.ToString("0000")}</td>";
                HTMLItens += $"      <td style=\"font-weight: bold; width: 40%\"><span>Serviço: </span></td>";
                HTMLItens += $"      <td>{tipoServicoEN.Descricao}</td>";
                HTMLItens += $"      <td style=\"font-weight: bold; width: 10%\"><span>Obs: </span></td>";
                HTMLItens += $"      <td>{itemOS.Observacao}</td>";
                HTMLItens += $"  </tr>";
            }
            HTMLItens += "  </table>";

            osTemplate.OrdemServicoItens = HTMLItens;

            string caminhoArquivoHTML = @"wwwroot\templates\OrdemServico.html";
            string caminhoBaseArquivo = @"wwwroot\templates\";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, osTemplate);

            return documentoBase64;
        }
    }
}
