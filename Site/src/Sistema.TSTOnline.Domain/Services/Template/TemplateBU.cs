using Sistema.Documentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Templates.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Templates.OrdemServico;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.Template
{
    public class TemplateBU
    {
        #region Variables

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

        private readonly IRepository<FluxoCaixaEN> _fluxoCaixaRepository;

        private readonly IRepository<ContasReceberEN> _contasReceberRepository;

        private readonly IDocumento _documentoService;

        #endregion Variables

        #region Constructor

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

                IRepository<FluxoCaixaEN> fluxoCaixaRepository,

                IRepository<ContasReceberEN> contasReceberRepository,

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

            _fluxoCaixaRepository = fluxoCaixaRepository;

            _contasReceberRepository = contasReceberRepository;

            _documentoService = documentoService;
        }

        #endregion Constructor

        #region Ordem de Serviço
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

        #endregion Ordem de Serviço

        #region Pedido de Venda

        public string PedidoVendaImprimir(int IDPedidoVenda, string CaminhoTemplate)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);
            EmpresaEN empresa = _empresaRepository.GetByID(pedidoVendaEN.IDEmpresa);
            VendedorEN vendedor = _vendedorRepository.GetByID(pedidoVendaEN.IDVendedor);
            var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == IDPedidoVenda);
            decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);
            decimal valorParcela = valorTotalPedido / (int)pedidoVendaEN.QtdeParcelas;

            PedidoVendaTemplate pvTemplate = new PedidoVendaTemplate()
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
                VendedorEmail = vendedor.Email,
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

            pvTemplate.PedidoVendaItens = HTMLItens;

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}PedidoVenda.html";

            var documentoBase64 = _documentoService.GerarDocumento<PedidoVendaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvTemplate);

            return documentoBase64;
        }

        #endregion Pedido de Venda

        #region Fluxo de Caixa
        public string FluxoCaixaImprimir(int IDFluxoCaixa, string CaminhoTemplate)
        {
            FluxoCaixaEN fluxoCaixaEN = _fluxoCaixaRepository.GetByID(IDFluxoCaixa);
            EmpresaEN empresa = null;

            string numeroPedidoVenda = string.Empty;
            string clienteCNPJ = string.Empty;
            string clienteRazaoSocial = string.Empty;
            string clienteEmail = string.Empty;
            string clienteCEP = string.Empty;
            string clienteEndereco = string.Empty;
            string clienteComplemento = string.Empty;
            string clienteNumero = string.Empty;
            string clienteBairro = string.Empty;
            string clienteCidade = string.Empty;
            string clienteContato = string.Empty;
            string clienteTelefone = string.Empty;
            string clienteCelular = string.Empty;

            if (fluxoCaixaEN.Origem == OrigemFluxoCaixaEnum.ContasReceber)
            {
                ContasReceberEN contasReceberEN = _contasReceberRepository.GetByID(fluxoCaixaEN.Chave);
                empresa = _empresaRepository.GetByID(contasReceberEN.IDEmpresa);

                if (contasReceberEN.Origem == OrigemContasReceberEnum.PedidoVenda)
                {
                    numeroPedidoVenda = contasReceberEN.Chave.ToString("00000");
                }
            }

            if (empresa != null)
            {
                clienteCNPJ = empresa.NrMatricula;
                clienteRazaoSocial = empresa.RazaoSocial;
                clienteEmail = empresa.Email;
                clienteCEP = Sistema.Utils.Helper.FormatarCEP(empresa.Cep);
                clienteEndereco = empresa.Endereco;
                clienteComplemento = empresa.Complemento;
                clienteNumero = empresa.Numero;
                clienteBairro = empresa.Bairro;
                clienteCidade = empresa.Cidade;
                clienteContato = empresa.NomeContato;
                clienteTelefone = empresa.Telefone;
                clienteCelular = empresa.Celular;
            }

            FluxoCaixaTemplate fcTemplate = new FluxoCaixaTemplate()
            {
                FluxoCaixaCodigo = fluxoCaixaEN.IDFluxoCaixa.ToString("000000"),
                DataInclusao = DateTime.Now.ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToString("HH:mm:sss"),
                FluxoCaixaDataLancamento = fluxoCaixaEN.DataLancamento.ToString("dd/MM/yyyy"),
                FluxoCaixaTipoLancamento = fluxoCaixaEN.TipoLancamento.ToDescriptionEmum(),
                FluxoCaixaOrigem = fluxoCaixaEN.Origem.ToDescriptionEmum(),
                PedidoVendaNumero = numeroPedidoVenda,
                FluxoCaixaObservacao = fluxoCaixaEN.Observacao,
                FluxoCaixaValor = Sistema.Utils.Helper.FormatReal(fluxoCaixaEN.Valor, true),
                ClienteCNPJ = clienteCNPJ,
                ClienteRazaoSocial = clienteRazaoSocial,
                ClienteEmail = clienteEmail,
                ClienteCEP = clienteCEP,
                ClienteEndereco = clienteEndereco,
                ClienteComplemento = clienteComplemento,
                ClienteNumero = clienteNumero,
                ClienteBairro = clienteBairro,
                ClienteCidade = clienteCidade,
                ClienteContato = clienteContato,
                ClienteTelefone = clienteTelefone,
                ClienteCelular = clienteCelular,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now),
            };

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}FluxoCaixa.html";

            var documentoBase64 = _documentoService.GerarDocumento<FluxoCaixaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, fcTemplate);

            return documentoBase64;
        }

        #endregion Fluxo de Caixa
    }
}
