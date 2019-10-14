using Sistema.Documentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Templates.OrdemServico;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.Template
{
    public class TemplateBU
    {
        private readonly IRepository<OrdemServicoEN> _repositoryOrdemServico;
        private readonly IRepository<OrdemServicoItemEN> _repositoryOrdemServicoItem;

        private readonly IRepository<PedidoVendaEN> _repositoryPedidoVenda;
        private readonly IRepository<PedidoVendaItemEN> _repositoryPedidoVendaItem;

        private readonly IRepository<ResponsavelEN> _responsavelRepository;

        private readonly IRepository<VendedorEN> _vendedorRepository;

        private readonly IRepository<EmpresaEN> _empresaRepository;

        private readonly IRepository<LocalServicoEN> _localServicoRepository;

        private readonly IRepository<TipoServicoEN> _tipoServicoRepository;

        private readonly IRepository<ProdutoEN> _produtoRepository;

        private readonly IDocumento _documentoService;

        public TemplateBU
            (
                IRepository<OrdemServicoEN> repositoryOrdemServico,
                IRepository<OrdemServicoItemEN> repositoryOrdemServicoItem,

                IRepository<PedidoVendaEN> repositoryPedidoVenda,
                IRepository<PedidoVendaItemEN> repositoryPedidoVendaItem,

                IRepository<ResponsavelEN> responsavelRepository,

                IRepository<VendedorEN> vendedorRepository,

                IRepository<EmpresaEN> empresaRepository,

                IRepository<LocalServicoEN> localServicoRepository,

                IRepository<TipoServicoEN> tipoServicoRepository,

                IRepository<ProdutoEN> produtoRepository,

                IDocumento documentoService
            )
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _repositoryOrdemServicoItem = repositoryOrdemServicoItem;

            _repositoryPedidoVenda = repositoryPedidoVenda;
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;

            _responsavelRepository = responsavelRepository;

            _vendedorRepository = vendedorRepository;

            _empresaRepository = empresaRepository;

            _localServicoRepository = localServicoRepository;

            _tipoServicoRepository = tipoServicoRepository;

            _produtoRepository = produtoRepository;

            _documentoService = documentoService;
        }

        public string OrdemServicoImprimir(int IDOrdemServico, string CaminhoTemplate)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);
            var listOrdemServicoItem = _repositoryOrdemServicoItem.Where(obj => obj.IDOrdemServico == IDOrdemServico);
            LocalServicoEN localServivoEN = _localServicoRepository.GetByID(ordemServicoEN.IDLocal);

            OrdemServicoTemplate osTemplate = new OrdemServicoTemplate()
            {
                OrdemServicoNumero = ordemServicoEN.IDOrdemServico.ToString("000000"),
                DataInclusao = DateTime.Now.ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToString("HH:mm:sss"),
                OrdemServicoData = ordemServicoEN.DataServico.ToString("dd/MM/yyyy"),
                OrdemServicoStatus = ordemServicoEN.Status.ToDescriptionEmum(),
                ClienteRazaoSocial = _empresaRepository.GetByID(ordemServicoEN.IDEmpresa).RazaoSocial,
                ResponsavelNome = _responsavelRepository.GetByID(ordemServicoEN.IDResp).NomeResponsavel,
                LocalNome = localServivoEN.Nome,
                LocalCEP = Sistema.Utils.Helper.FormatarCEP(localServivoEN.CEP),
                LocalEndereco = localServivoEN.Endereco,
                LocalNumero = localServivoEN.Numero,
                LocalComplemento = localServivoEN.Complemento,
                LocalBairro = localServivoEN.Bairro,
                LocalCidade = localServivoEN.Cidade,
                ContatoNome = ordemServicoEN.NomeContato,
                ContatoTelefone = ordemServicoEN.Telefone,
                ContatoWhatsApp = ordemServicoEN.WhatsApp,

                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now),
            };

            var HTMLItens = "<table>";
            HTMLItens += $"     <tr>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 10%\"><span>Item</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 30%\"><span>Serviço</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 10%\"><span>Concluído</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 50%\"><span>Observações</span></td>";
            HTMLItens += $"     </tr>";
            foreach (var itemOS in listOrdemServicoItem)
            {
                TipoServicoEN tipoServicoEN = _tipoServicoRepository.GetByID(itemOS.IDTipoServico);
                var concluido = itemOS.Concluido ? "SIM" : "NÃO";

                HTMLItens += $"  <tr>";
                HTMLItens += $"      <td>{itemOS.Item.ToString("0000")}</td>";
                HTMLItens += $"      <td>{tipoServicoEN.Descricao}</td>";
                HTMLItens += $"      <td>{concluido}</td>";
                HTMLItens += $"      <td>{itemOS.Observacao}</td>";
                HTMLItens += $"  </tr>";
            }
            HTMLItens += "  </table>";

            osTemplate.OrdemServicoItens = HTMLItens;

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}OrdemServico.html";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, osTemplate);

            return documentoBase64;
        }

        public string PedidoVendaImprimir(int IDPedidoVenda, string CaminhoTemplate)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);
            var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == IDPedidoVenda);
            var empresa = _empresaRepository.GetByID(pedidoVendaEN.IDEmpresa);
            var vendedor = _vendedorRepository.GetByID(pedidoVendaEN.IDVendedor);
            decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);
            decimal valorParcela = valorTotalPedido / (int)pedidoVendaEN.QtdeParcelas;

            PedidoVendaTemplate osTemplate = new PedidoVendaTemplate()
            {
                PedidoVendaNumero = pedidoVendaEN.IDPedido.ToString("000000"),
                DataInclusao = DateTime.Now.ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToString("HH:mm:sss"),
                PedidoVendaData = pedidoVendaEN.DataVenda.ToString("dd/MM/yyyy"),
                PedidoVendaStatus = pedidoVendaEN.Status.ToDescriptionEmum(),
                PedidoVendaObservacao = pedidoVendaEN.Observacao,
                ClienteCNPJ = empresa.NrMatricula,
                ClienteRazaoSocial = empresa.RazaoSocial,
                ClienteEmail = empresa.Email,
                ClienteCEP = Sistema.Utils.Helper.FormatarCEP(empresa.Cep),
                ClienteEndereco = empresa.Endereco,
                ClienteComplemento = empresa.Complemento,
                ClienteNumero = empresa.Numero,
                ClienteBairro = empresa.Bairro,
                ClienteCidade = empresa.Cidade,
                ClienteContato = empresa.NomeContato,
                ClienteTelefone = empresa.Telefone,
                ClienteCelular = empresa.Celular,
                ResponsavelCPF = empresa.CPFResponsavel,
                ResponsavelNome = empresa.NomeRespEmpresa,
                VendedorNome = vendedor.Nome,
                VendedorTelefone = vendedor.Telefone,
                VendedorWhatsApp = vendedor.WhatsApp,
                PedidoFormaPagamento = pedidoVendaEN.TipoPagamento.ToDescriptionEmum(),
                PedidoQtdeParcelas = pedidoVendaEN.QtdeParcelas.ToDescriptionEmum(),
                PedidoValorParcela = Sistema.Utils.Helper.FormatReal(valorParcela, true),
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now),
            };

            var HTMLItens = "<table>";
            HTMLItens += $"     <tr>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 10%\"><span>Item</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 30%\"><span>Produto</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 10%\"><span>Qtde</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 25%\"><span>Valor Unitário</span></td>";
            HTMLItens += $"         <td style=\"font-weight: bold; width: 25%\"><span>Valor Total</span></td>";
            HTMLItens += $"     </tr>";
            foreach (var itemPedido in listPedidoVendaItem)
            {
                ProdutoEN produtoEN = _produtoRepository.GetByID(itemPedido.IDProduto);

                HTMLItens += $"  <tr>";
                HTMLItens += $"      <td>{itemPedido.Item.ToString("0000")}</td>";
                HTMLItens += $"      <td>{produtoEN.Nome}</td>";
                HTMLItens += $"      <td>{itemPedido.Qtde}</td>";
                HTMLItens += $"      <td>{Sistema.Utils.Helper.FormatReal(itemPedido.Valor, true)}</td>";
                HTMLItens += $"      <td>{Sistema.Utils.Helper.FormatReal(itemPedido.ValorTotal, true)}</td>";
                HTMLItens += $"  </tr>";
            }

            HTMLItens += $"      <tr>";
            HTMLItens += $"          <td colspan=\"5\" style=\"text-align:left; padding-left:290px;\"><hr style=\"border: dashed 1px #6a6d73; width: 260px;\" /></td>";
            HTMLItens += $"      </tr>";

            HTMLItens += $"      <tr>";
            HTMLItens += $"          <td>&nbsp;</td>";
            HTMLItens += $"          <td>&nbsp;</td>";
            HTMLItens += $"          <td>&nbsp;</td>";
            HTMLItens += $"          <td style=\"text-align:center;\"><strong>Total do Pedido</strong></td>";
            HTMLItens += $"          <td><strong>{Sistema.Utils.Helper.FormatReal(valorTotalPedido, true)}</strong></td>";
            HTMLItens += $"      </tr>";

            HTMLItens += "  </table>";

            osTemplate.PedidoVendaItens = HTMLItens;

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}PedidoVenda.html";

            var documentoBase64 = _documentoService.GerarDocumento<PedidoVendaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, osTemplate);

            return documentoBase64;
        }
    }
}
