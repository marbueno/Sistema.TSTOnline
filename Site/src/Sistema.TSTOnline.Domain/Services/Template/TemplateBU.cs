﻿using Sistema.Documentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.Relatorios;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Usuario;
using Sistema.TSTOnline.Domain.Templates.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Templates.OrdemServico;
using Sistema.TSTOnline.Domain.Templates.PedidoVenda;
using Sistema.TSTOnline.Domain.Templates.Relatorios;
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

        private readonly IRepository<CompanyEN> _companyRepository;

        private readonly IRepository<EmpresaEN> _empresaRepository;

        private readonly IRepository<LocalServicoEN> _localServicoRepository;

        private readonly IRepository<TipoServicoEN> _tipoServicoRepository;

        private readonly IRepository<ProdutoEN> _produtoRepository;

        private readonly IRepository<FluxoCaixaEN> _fluxoCaixaRepository;

        private readonly IRepository<ContasReceberEN> _contasReceberRepository;

        private readonly IRepository<VendasPorVendedorEN> _repositoryVendasPorVendedor;

        private readonly IRepository<VendasPorClienteEN> _repositoryVendasPorCliente;

        private readonly IRepository<VendasDetalhadasEN> _repositoryVendasDetalhadas;

        private readonly IRepository<VendasPorProdutoEN> _repositoryVendasPorProduto;

        private readonly IRepository<MovimentacaoEstoqueEN> _repositoryMovimentacaoEstoque;

        private readonly IRepository<OrdemServicoPorTecnicoEN> _repositoryOrdemServicoPorTecnico;

        private readonly IRepository<OrdemServicoPorClienteEN> _repositoryOrdemServicoPorCliente;

        private readonly IRepository<OrdemServicoDetalhadaEN> _repositoryOrdemServicoDetalhada;

        private readonly IRepository<OrdemServicoPorTipoEN> _repositoryOrdemServicoPorTipo;

        private readonly IRepository<MovimentacaoFinanceiraContasReceberEN> _repositoryMovimentacaoFinanceiraContasReceber;

        private readonly IRepository<MovimentacaoFinanceiraFluxoCaixaEN> _repositoryMovimentacaoFinanceiraFluxoCaixa;

        private readonly IDocumento _documentoService;

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

        private CompanyEN _company => _companyRepository.GetByID(idCompany);

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

                IRepository<CompanyEN> companyRepository,

                IRepository<EmpresaEN> empresaRepository,

                IRepository<LocalServicoEN> localServicoRepository,

                IRepository<TipoServicoEN> tipoServicoRepository,

                IRepository<ProdutoEN> produtoRepository,

                IRepository<FluxoCaixaEN> fluxoCaixaRepository,

                IRepository<ContasReceberEN> contasReceberRepository,

                IRepository<VendasPorVendedorEN> repositoryVendasPorVendedor,

                IRepository<VendasPorClienteEN> repositoryVendasPorCliente,

                IRepository<VendasDetalhadasEN> repositoryVendasDetalhadas,

                IRepository<VendasPorProdutoEN> repositoryVendasPorProduto,

                IRepository<MovimentacaoEstoqueEN> repositoryMovimentacaoEstoque,

                IRepository<OrdemServicoPorTecnicoEN> repositoryOrdemServicoPorTecnico,

                IRepository<OrdemServicoPorClienteEN> repositoryOrdemServicoPorCliente,

                IRepository<OrdemServicoDetalhadaEN> repositoryOrdemServicoDetalhada,

                IRepository<OrdemServicoPorTipoEN> repositoryOrdemServicoPorTipo,

                IRepository<MovimentacaoFinanceiraContasReceberEN> repositoryMovimentacaoFinanceiraContasReceber,

                IRepository<MovimentacaoFinanceiraFluxoCaixaEN> repositoryMovimentacaoFinanceiraFluxoCaixa,

                IDocumento documentoService,

                UsuarioService usuarioService
            )
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _repositoryOrdemServicoItem = repositoryOrdemServicoItem;

            _repositoryPedidoVenda = repositoryPedidoVenda;
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;

            _responsavelRepository = responsavelRepository;

            _vendedorRepository = vendedorRepository;

            _companyRepository = companyRepository;

            _empresaRepository = empresaRepository;

            _localServicoRepository = localServicoRepository;

            _tipoServicoRepository = tipoServicoRepository;

            _produtoRepository = produtoRepository;

            _fluxoCaixaRepository = fluxoCaixaRepository;

            _contasReceberRepository = contasReceberRepository;

            _repositoryVendasPorVendedor = repositoryVendasPorVendedor;

            _repositoryVendasPorCliente = repositoryVendasPorCliente;

            _repositoryVendasDetalhadas = repositoryVendasDetalhadas;

            _repositoryVendasPorProduto = repositoryVendasPorProduto;

            _repositoryMovimentacaoEstoque = repositoryMovimentacaoEstoque;

            _repositoryOrdemServicoPorTecnico = repositoryOrdemServicoPorTecnico;

            _repositoryOrdemServicoPorCliente = repositoryOrdemServicoPorCliente;

            _repositoryOrdemServicoDetalhada = repositoryOrdemServicoDetalhada;

            _repositoryOrdemServicoPorTipo = repositoryOrdemServicoPorTipo;

            _repositoryMovimentacaoFinanceiraContasReceber = repositoryMovimentacaoFinanceiraContasReceber;

            _repositoryMovimentacaoFinanceiraFluxoCaixa = repositoryMovimentacaoFinanceiraFluxoCaixa;

            _documentoService = documentoService;

            _usuarioService = usuarioService;
        }

        #endregion Constructor

        #region Ordem de Serviço
        public string OrdemServicoImprimir(int IDOrdemServico, string CaminhoTemplate)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);
            var listOrdemServicoItem = _repositoryOrdemServicoItem.Where(obj => obj.IDOrdemServico == IDOrdemServico);
            var empresa = _empresaRepository.GetByID(ordemServicoEN.IDEmpresa);
            LocalServicoEN localServivoEN = _localServicoRepository.GetByID(ordemServicoEN.IDLocal);

            OrdemServicoTemplate osTemplate = new OrdemServicoTemplate()
            {
                OrdemServicoNumero = ordemServicoEN.IDOrdemServico.ToString("000000"),
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                OrdemServicoData = $"{ordemServicoEN.DataServico.ToString("dd/MM/yyyy")} {ordemServicoEN.HorarioServico}",
                OrdemServicoStatus = ordemServicoEN.Status.ToDescriptionEnum(),
                CompanyCnpj = _company.Cnpj,
                CompanyRazaoSocial = _company.RazaoSocial,
                ClienteRazaoSocial = empresa.RazaoSocial,
                //ClienteRazaoEnderecoCompleto = $"{empresa.Endereco}, {empresa.Numero} - {empresa.Bairro} - {empresa.Cidade}/{empresa.UF}",
                //ClienteRazaoTelefoneCompleto = $"Fone: {empresa.Telefone}",
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

                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
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
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                PedidoVendaData = pedidoVendaEN.DataVenda.ToString("dd/MM/yyyy"),
                PedidoVendaStatus = pedidoVendaEN.Status.ToDescriptionEnum(),
                PedidoVendaObservacao = pedidoVendaEN.Observacao.Replace("\n", "<br />"),
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
                PedidoFormaPagamento = pedidoVendaEN.TipoPagamento.ToDescriptionEnum(),
                PedidoQtdeParcelas = pedidoVendaEN.QtdeParcelas.ToDescriptionEnum(),
                PedidoValorParcela = Sistema.Utils.Helper.FormatReal(valorParcela, true),
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            empresa = _empresaRepository.GetByID(vendedor.IDEmpresa);
            pvTemplate.VendedorEmpresa = _company.RazaoSocial;
            pvTemplate.VendedorEmpresaCnpj = _company.Cnpj;
            pvTemplate.VendedorEmpresaEnderecoCompleto = $"{empresa.Endereco}, {empresa.Numero} - {empresa.Bairro} - {empresa.Cidade}/{empresa.UF}";
            pvTemplate.VendedorEmpresaTelefoneCompleto = $"Fone: {empresa.Telefone}";

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
            string contasReceberParcela = string.Empty;
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
                contasReceberParcela = contasReceberEN.Seq.ToString();

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
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                FluxoCaixaDataLancamento = fluxoCaixaEN.DataLancamento.ToString("dd/MM/yyyy"),
                FluxoCaixaTipoLancamento = fluxoCaixaEN.TipoLancamento.ToDescriptionEnum(),
                FluxoCaixaOrigem = fluxoCaixaEN.Origem.ToDescriptionEnum(),
                PedidoVendaNumero = numeroPedidoVenda,
                ContasReceberParcela = contasReceberParcela,
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
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}FluxoCaixa.html";

            var documentoBase64 = _documentoService.GerarDocumento<FluxoCaixaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, fcTemplate);

            return documentoBase64;
        }

        #endregion Fluxo de Caixa

        #region Relatórios

        public string VendasPorVendedorImprimir(string CaminhoTemplate, int IDVendedor, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                ped.idpedido        as Id,
                                ped.idpedido        as IDPedido,
                                ped.datacadastro    as DataCadastro,
                                ped.datavenda       as DataVenda,
                                ped.status          as Status,
                                ven.idvendedor      as IDVendedor,
                                ven.nome            as NomeVendedor,
                                ven.email           as EmailVendedor
                              from tbpedidovenda ped
                             inner join tbcadvendedor ven on ped.idvendedor = ven.idvendedor
                             where ped.idcompany = {idCompany}
                               and ped.datavenda between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDVendedor != 0)
            {
                SQL += $" and ped.idvendedor = {IDVendedor.ToString()}";
            }

            var listPedidosVenda = _repositoryVendasPorVendedor.FromSql(SQL).OrderBy(e => e.NomeVendedor).ThenBy(e => e.IDPedido).ToList();

            string HTML = "";
            int idVendedor = 0;
            decimal valorTotalPorVendedor = 0;
            decimal valorTotalPorVendedorGeral = 0;

            foreach (var itemPedido in listPedidosVenda)
            {
                var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == itemPedido.IDPedido);
                decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);

                if (idVendedor != itemPedido.IDVendedor)
                {
                    if (idVendedor != 0)
                    {
                        HTML += $"<tr>";
                        HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
                        HTML += $"</tr>";

                        HTML += $"<tr>";
                        HTML += $"    <td style=\"text-align:right;\"><strong>Total Vendedor: {Sistema.Utils.Helper.FormatReal(valorTotalPorVendedor, true)}</strong></td>";
                        HTML += $"</tr>";

                        valorTotalPorVendedor = 0;
                    }

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #E00500;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Vendedor</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemPedido.NomeVendedor}</td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>E-mail</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemPedido.EmailVendedor}</td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Número Pedido</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Data da Venda</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Status</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:right;\"><span>Valor Pedido</span></td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";
                }

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.IDPedido.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.DataVenda.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.Status.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(valorTotalPedido, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";

                valorTotalPorVendedor += valorTotalPedido;
                valorTotalPorVendedorGeral += valorTotalPedido;

                idVendedor = itemPedido.IDVendedor;
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right;\"><strong>Total Vendedor: {Sistema.Utils.Helper.FormatReal(valorTotalPorVendedor, true)}</strong></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right;\"><strong>Total Geral: {Sistema.Utils.Helper.FormatReal(valorTotalPorVendedorGeral, true)}</strong></td>";
            HTML += $"</tr>";

            VendasPorVendedorTemplate pvRelatorio = new VendasPorVendedorTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };
            

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioVendasPorVendedor.html";

            var documentoBase64 = _documentoService.GerarDocumento<VendasPorVendedorTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string VendasPorClienteImprimir(string CaminhoTemplate, int IDEmpresa, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                ped.idpedido        as Id,
                                ped.idpedido        as IDPedido,
                                ped.datacadastro    as DataCadastro,
                                ped.datavenda       as DataVenda,
                                ped.status          as Status,
                                emp.idempresa       as IDEmpresa,
                                emp.razaosocial     as RazaoSocial,
                                emp.nomerespempresa as ResponsavelEmpresaNome,
                                ven.nome            as NomeVendedor
                              from tbpedidovenda ped
                             inner join tbcadempresas emp on ped.idempresa = emp.idempresa
                             inner join tbcadvendedor ven on ped.idvendedor = ven.idvendedor
                             where ped.idcompany = {idCompany}
                               and ped.datavenda between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and ped.idempresa = {IDEmpresa.ToString()}";
            }

            var listPedidosVenda = _repositoryVendasPorCliente.FromSql(SQL).OrderBy(e => e.RazaoSocial).ThenBy(e => e.IDPedido).ToList();

            string HTML = "";
            int idEmpresa = 0;

            foreach (var itemPedido in listPedidosVenda)
            {
                var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == itemPedido.IDPedido);
                decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);

                if (idEmpresa != itemPedido.IDEmpresa)
                {
                    if (idEmpresa != 0)
                    {
                        HTML += $"<tr>";
                        HTML += $"   <td>";
                        HTML += $"       <hr style=\"border: dashed 1px #6a6d73;\">";
                        HTML += $"   </td>";
                        HTML += $"</tr>";
                    }

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #E00500;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Cliente</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemPedido.RazaoSocial}</td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Responsável</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemPedido.ResponsavelEmpresaNome}</td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Número Pedido</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Data da Venda</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Vendedor</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Status</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:right;\"><span>Valor Pedido</span></td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";
                }

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.IDPedido.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.DataVenda.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.NomeVendedor}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.Status.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(valorTotalPedido, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";

                idEmpresa = itemPedido.IDEmpresa;
            }

            VendasPorClienteTemplate pvRelatorio = new VendasPorClienteTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };


            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioVendasPorCliente.html";

            var documentoBase64 = _documentoService.GerarDocumento<VendasPorClienteTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string VendasDetalhadasImprimir(string CaminhoTemplate, int IDEmpresa, int IDVendedor, PedidoVendaStatusEnum IDStatus, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                ped.idpedido        as Id,
                                ped.idpedido        as IDPedido,
                                ped.datacadastro    as DataCadastro,
                                ped.datavenda       as DataVenda,
                                flc.datalancamento  as DataPagamento,
                                ped.status          as Status,
                                emp.razaosocial     as RazaoSocial,
                                ven.nome            as NomeVendedor
                              from tbpedidovenda ped
                             inner join tbcadempresas emp on ped.idempresa = emp.idempresa
                             inner join tbcadvendedor ven on ped.idvendedor = ven.idvendedor
                              left join tbcontasreceber ctr on ped.idpedido = ctr.chave
                                                           and ctr.origem = 2
                              left join tbfluxocaixa flc on ctr.idcontasreceber = flc.chave
                                                           and flc.origem = 2
                             where ped.idcompany = {idCompany}
                               and ped.datavenda between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and ped.idempresa = {IDEmpresa.ToString()}";
            }

            if (IDVendedor != 0)
            {
                SQL += $" and ped.idvendedor = {IDVendedor.ToString()}";
            }

            if (IDStatus != PedidoVendaStatusEnum.Todos)
            {
                SQL += $" and ped.status = {(int)IDStatus}";
            }

            var listPedidosVenda = _repositoryVendasDetalhadas.FromSql(SQL).OrderByDescending(e => e.IDPedido).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Nro Ped</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Dt Criação</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Dt Venda</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Dt Pagto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 32%; text-align:left;\"><span>Cliente</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Vendedor</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Status</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:right;\"><span>Vlr Pedido</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            decimal valorTotalGeral = 0;

            foreach (var itemPedido in listPedidosVenda)
            {
                var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == itemPedido.IDPedido);
                decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);
                valorTotalGeral += valorTotalPedido;

                string dataPagamento = string.Empty;

                if (itemPedido.DataPagamento != null)
                    dataPagamento = ((DateTime)itemPedido.DataPagamento).ToString("dd/MM/yyyy");

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemPedido.IDPedido.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemPedido.DataCadastro.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemPedido.DataVenda.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{dataPagamento}</td>";
                HTML += $"               <td style=\"width: 32%; text-align:left;\">{itemPedido.RazaoSocial}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemPedido.NomeVendedor}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemPedido.Status.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(valorTotalPedido, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right;\"><strong>Total Geral: {Sistema.Utils.Helper.FormatReal(valorTotalGeral, true)}</strong></td>";
            HTML += $"</tr>";

            VendasDetalhadasTemplate pvRelatorio = new VendasDetalhadasTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                StatusFiltro = IDStatus.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDEmpresa == 0)
            {
                pvRelatorio.ClienteFiltro = "TODOS";
            }
            else
            {
                EmpresaEN empresa = _empresaRepository.GetByID(IDEmpresa);
                pvRelatorio.ClienteFiltro = empresa.RazaoSocial;
            }

            if (IDVendedor == 0)
            {
                pvRelatorio.VendedorFiltro = "TODOS";
            }
            else
            {
                VendedorEN vendedor = _vendedorRepository.GetByID(IDVendedor);
                pvRelatorio.VendedorFiltro = vendedor.Nome;
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioVendasDetalhadas.html";

            var documentoBase64 = _documentoService.GerarDocumento<VendasDetalhadasTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string VendasPorProdutoImprimir(string CaminhoTemplate, int IDEmpresa, int IDVendedor, PedidoVendaStatusEnum IDStatus, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                pvi.idpedidoitem        as Id,
                                pvi.idpedido            as IDPedido,
                                pvi.item                as Item,
                                prd.nome                as Produto,
                                pvi.qtde                as Qtde,
                                pvi.valor               as Valor,
                                pvi.qtde * pvi.valor    as ValorTotal

                              from tbpedidovendaitem pvi
                             inner join tbpedidovenda ped on pvi.idpedido = ped.idpedido
                             inner join tbproduto prd on pvi.idproduto = prd.idproduto
                             where ped.idcompany = {idCompany}
                               and ped.datavenda between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and ped.idempresa = {IDEmpresa.ToString()}";
            }

            if (IDVendedor != 0)
            {
                SQL += $" and ped.idvendedor = {IDVendedor.ToString()}";
            }

            if (IDStatus != PedidoVendaStatusEnum.Todos)
            {
                SQL += $" and ped.status = {(int)IDStatus}";
            }

            var listItensVenda = _repositoryVendasPorProduto.FromSql(SQL).OrderByDescending(e => e.IDPedido).ThenBy(e => e.Item).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Nro Ped</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Item</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\"><span>Produto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Qtde</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:right;\"><span>Valor</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:right;\"><span>Valor Total</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            decimal valorTotalGeral = 0;

            foreach (var itemPedido in listItensVenda)
            {
                valorTotalGeral += itemPedido.ValorTotal;

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemPedido.IDPedido.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemPedido.Item.ToString("000")}</td>";
                HTML += $"               <td style=\"width: 30%; text-align:left;\">{itemPedido.Produto}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemPedido.Qtde}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(itemPedido.Valor, true)}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(itemPedido.ValorTotal, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right;\"><strong>Total Geral: {Sistema.Utils.Helper.FormatReal(valorTotalGeral, true)}</strong></td>";
            HTML += $"</tr>";

            VendasPorProdutoTemplate pvRelatorio = new VendasPorProdutoTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                StatusFiltro = IDStatus.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDEmpresa == 0)
            {
                pvRelatorio.ClienteFiltro = "TODOS";
            }
            else
            {
                EmpresaEN empresa = _empresaRepository.GetByID(IDEmpresa);
                pvRelatorio.ClienteFiltro = empresa.RazaoSocial;
            }

            if (IDVendedor == 0)
            {
                pvRelatorio.VendedorFiltro = "TODOS";
            }
            else
            {
                VendedorEN vendedor = _vendedorRepository.GetByID(IDVendedor);
                pvRelatorio.VendedorFiltro = vendedor.Nome;
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioVendasPorProduto.html";

            var documentoBase64 = _documentoService.GerarDocumento<VendasPorProdutoTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string MovimentacaoEstoqueImprimir(string CaminhoTemplate, OrigemMovimentoEstoqueEnum IDOrigem, TipoMovimentoEstoqueEnum IDTipo, int IDProduto, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                mve.idmovimento         as Id,
                                ped.idpedido            as IDPedido,
                                mve.datamovimento       as DataMovimento,
                                mve.origem              as Origem,
                                mve.tipo                as Tipo,
                                prd.nome                as Produto,
                                mve.qtde                as Qtde,
                                mve.observacao          as Observacao
                              from tbmovimentoestoque mve
                             inner join tbproduto prd on mve.idproduto = prd.idproduto
                              left join tbpedidovenda ped on mve.chave = ped.idpedido
                                                         and mve.origem = 2
                             where mve.idcompany = {idCompany}
                               and mve.datamovimento between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if ((int)IDOrigem != 0)
            {
                SQL += $" and mve.origem = {(int)IDOrigem}";
            }

            if ((int)IDTipo != 0)
            {
                SQL += $" and mve.tipo = {(int)IDTipo}";
            }

            if (IDProduto != 0)
            {
                SQL += $" and mve.idproduto = {IDProduto}";
            }

            var listMovimentacaoEstoque = _repositoryMovimentacaoEstoque.FromSql(SQL).OrderBy(e => e.Id).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Mov</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Data Mov</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 26%; text-align:left;\"><span>Produto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Origem</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Pedido</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Tipo</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 21%; text-align:left;\"><span>Observação</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 05%; text-align:center;\"><span>Qtde</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            decimal qtdeGeral = 0;

            foreach (var itemMov in listMovimentacaoEstoque)
            {
                if (itemMov.Tipo == TipoMovimentoEstoqueEnum.Entrada)
                    qtdeGeral += itemMov.Qtde;
                else
                    qtdeGeral -= itemMov.Qtde;

                string numeroPedido = string.Empty;

                if (itemMov.Origem == OrigemMovimentoEstoqueEnum.PedidoVenda)
                    numeroPedido = ((int)itemMov.IDPedido).ToString("000000");

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemMov.Id.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemMov.DataMovimento.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 26%; text-align:left;\">{itemMov.Produto}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemMov.Origem.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{numeroPedido}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemMov.Tipo.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 21%; text-align:left;\">{itemMov.Observacao}</td>";
                HTML += $"               <td style=\"width: 05%; text-align:center;\">{itemMov.Qtde}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right;\"><strong>Qtde Total: {qtdeGeral}</strong></td>";
            HTML += $"</tr>";

            MovimentacaoEstoqueTemplate pvRelatorio = new MovimentacaoEstoqueTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                OrigemFiltro = IDOrigem.ToDescriptionEnum(),
                TipoFiltro = IDTipo.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if ((int)IDOrigem == 0)
            {
                pvRelatorio.OrigemFiltro = "TODAS";
            }
            else
            {
                pvRelatorio.OrigemFiltro = IDOrigem.ToDescriptionEnum();
            }

            if ((int)IDTipo == 0)
            {
                pvRelatorio.TipoFiltro = "TODOS";
            }
            else
            {
                pvRelatorio.TipoFiltro = IDTipo.ToDescriptionEnum();
            }

            if (IDProduto == 0)
            {
                pvRelatorio.ProdutoFiltro = "TODOS";
            }
            else
            {
                ProdutoEN produto = _produtoRepository.GetByID(IDProduto);
                pvRelatorio.ProdutoFiltro = produto.Nome;
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioMovimentacaoEstoque.html";

            var documentoBase64 = _documentoService.GerarDocumento<MovimentacaoEstoqueTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string OrdemServicoPorTecnicoImprimir(string CaminhoTemplate, int IDResp, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                osr.idordemservico  as Id,
                                osr.idordemservico  as IDOrdemServico,
                                osr.datacadastro    as DataCadastro,
                                osr.dataservico     as DataServico,
                                osr.horarioservico  as HorarioServico,
                                osr.status          as Status,
                                res.idresp          as IDResp,
                                res.nomeresponsavel as NomeResponsavel,
                                res.email           as EmailResponsavel
                              from tbos osr
                             inner join tbresponsavel res on osr.idresp = res.idresp
                             where osr.idcompany = {idCompany}
                               and osr.dataservico between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDResp != 0)
            {
                SQL += $" and osr.idresp = {IDResp.ToString()}";
            }

            var listOrdemServico = _repositoryOrdemServicoPorTecnico.FromSql(SQL).OrderBy(e => e.NomeResponsavel).ThenBy(e => e.IDOrdemServico).ToList();

            string HTML = "";
            int idResp = 0;

            foreach (var itemOS in listOrdemServico)
            {
                if (idResp != itemOS.IDResp)
                {
                    if (idResp != 0)
                    {
                        HTML += $"<tr>";
                        HTML += $"   <td>";
                        HTML += $"       <hr style=\"border: dashed 1px #6a6d73;\">";
                        HTML += $"   </td>";
                        HTML += $"</tr>";
                    }

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #E00500;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Técnico</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemOS.NomeResponsavel}</td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>E-mail</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemOS.EmailResponsavel}</td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Número O.S.</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Data do Serviço</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Horário Serviço</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Status</span></td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";
                }

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.IDOrdemServico.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.DataServico.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.HorarioServico}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.Status.ToDescriptionEnum()}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";

                idResp = itemOS.IDResp;
            }

            OrdemServicoPorTipoTemplate pvRelatorio = new OrdemServicoPorTipoTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioOrdemServicoPorTecnico.html";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoPorTipoTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string OrdemServicoPorClienteImprimir(string CaminhoTemplate, int IDEmpresa, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                osr.idordemservico  as Id,
                                osr.idordemservico  as IDOrdemServico,
                                osr.datacadastro    as DataCadastro,
                                osr.dataservico     as DataServico,
                                osr.horarioservico  as HorarioServico,
                                osr.status          as Status,
                                emp.idempresa       as IDEmpresa,
                                emp.razaosocial     as RazaoSocial,
                                emp.nomerespempresa as ResponsavelEmpresaNome,
                                res.nomeresponsavel as NomeResponsavel
                              from tbos osr
                             inner join tbcadempresas emp on osr.idempresa = emp.idempresa
                             inner join tbresponsavel res on osr.idresp = res.idresp
                             where osr.idcompany = {idCompany}
                               and osr.dataservico between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and osr.idempresa = {IDEmpresa.ToString()}";
            }

            var listOrdemServico = _repositoryOrdemServicoPorCliente.FromSql(SQL).OrderBy(e => e.RazaoSocial).ThenBy(e => e.IDOrdemServico).ToList();

            string HTML = "";
            int idEmpresa = 0;

            foreach (var itemOS in listOrdemServico)
            {
                if (idEmpresa != itemOS.IDEmpresa)
                {
                    if (idEmpresa != 0)
                    {
                        HTML += $"<tr>";
                        HTML += $"   <td>";
                        HTML += $"       <hr style=\"border: dashed 1px #6a6d73;\">";
                        HTML += $"   </td>";
                        HTML += $"</tr>";
                    }

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #E00500;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Cliente</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemOS.RazaoSocial}</td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><strong>Responsável</strong></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\">{itemOS.ResponsavelEmpresaNome}</td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";

                    HTML += $"<tr>";
                    HTML += $"   <td>";
                    HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                    HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Número O.S.</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Data do Serviço</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Horário Serviço</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Técnico</span></td>";
                    HTML += $"               <td style=\"font-weight: bold; width: 20%; text-align:left;\"><span>Status</span></td>";
                    HTML += $"          </tr>";
                    HTML += $"       </table>";
                    HTML += $"   </td>";
                    HTML += $"</tr>";
                }

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.IDOrdemServico.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.DataServico.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.HorarioServico.ToString()}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.NomeResponsavel}</td>";
                HTML += $"               <td style=\"width: 20%; text-align:left;\">{itemOS.Status.ToDescriptionEnum()}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";

                idEmpresa = itemOS.IDEmpresa;
            }

            OrdemServicoPorClienteTemplate pvRelatorio = new OrdemServicoPorClienteTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioOrdemServicoPorCliente.html";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoPorClienteTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string OrdemServicoDetalhadaImprimir(string CaminhoTemplate, int IDEmpresa, int IDResp, OrdemServicoStatusEnum IDStatus, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                osr.idordemservico  as Id,
                                osr.idordemservico  as IDOrdemServico,
                                osr.datacadastro    as DataCadastro,
                                osr.dataservico     as DataServico,
                                osr.horarioservico  as HorarioServico,
                                osr.status          as Status,
                                emp.razaosocial     as RazaoSocial,
                                res.nomeresponsavel as NomeResponsavel
                              from tbos osr
                             inner join tbcadempresas emp on osr.idempresa = emp.idempresa
                             inner join tbresponsavel res on osr.idresp = res.idresp
                             where osr.idcompany = {idCompany}
                               and osr.dataservico between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and osr.idempresa = {IDEmpresa.ToString()}";
            }

            if (IDResp != 0)
            {
                SQL += $" and osr.idresp = {IDResp.ToString()}";
            }

            if (IDStatus != OrdemServicoStatusEnum.Todos)
            {
                SQL += $" and osr.status = {(int)IDStatus}";
            }

            var listOrdemServico = _repositoryOrdemServicoDetalhada.FromSql(SQL).OrderByDescending(e => e.IDOrdemServico).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Nro O.S.</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Dt Criação</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Dt Serviço</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 7%; text-align:left;\"><span>Hr Serviço</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 32%; text-align:left;\"><span>Cliente</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\"><span>Técnico</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Status</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";
            
            foreach (var itemOS in listOrdemServico)
            {
                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemOS.IDOrdemServico.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemOS.DataCadastro.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemOS.DataServico.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 7%; text-align:left;\">{itemOS.HorarioServico}</td>";
                HTML += $"               <td style=\"width: 32%; text-align:left;\">{itemOS.RazaoSocial}</td>";
                HTML += $"               <td style=\"width: 30%; text-align:left;\">{itemOS.NomeResponsavel}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemOS.Status.ToDescriptionEnum()}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }
                        
            OrdemServicoDetalhadaTemplate pvRelatorio = new OrdemServicoDetalhadaTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                StatusFiltro = IDStatus.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDEmpresa == 0)
            {
                pvRelatorio.ClienteFiltro = "TODOS";
            }
            else
            {
                EmpresaEN empresa = _empresaRepository.GetByID(IDEmpresa);
                pvRelatorio.ClienteFiltro = empresa.RazaoSocial;
            }

            if (IDResp == 0)
            {
                pvRelatorio.ResponsavelFiltro = "TODOS";
            }
            else
            {
                ResponsavelEN responsavel = _responsavelRepository.GetByID(IDResp);
                pvRelatorio.ResponsavelFiltro = responsavel.NomeResponsavel;
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioOrdemServicoDetalhada.html";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoDetalhadaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string OrdemServicoPorTipoImprimir(string CaminhoTemplate, int IDEmpresa, int IDResp, OrdemServicoStatusEnum IDStatus, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                osi.idordemservicoitem  as Id,
                                osi.idordemservico      as IDOrdemServico,
                                osi.item                as Item,
                                tps.descricao           as TipoServico,
                                osi.observacao          as Observacao,
                                osi.concluido           as Concluido

                              from tbositem osi
                             inner join tbos osr on osi.idordemservico = osr.idordemservico
                             inner join tbcadtiposervico tps on osi.idtiposervico = tps.idtiposervico
                             where osr.idcompany = {idCompany}
                               and osr.dataservico between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and osr.idempresa = {IDEmpresa.ToString()}";
            }

            if (IDResp != 0)
            {
                SQL += $" and osr.idresp = {IDResp.ToString()}";
            }

            if (IDStatus != OrdemServicoStatusEnum.Todos)
            {
                SQL += $" and osr.status = {(int)IDStatus}";
            }

            var listItensOS = _repositoryOrdemServicoPorTipo.FromSql(SQL).OrderByDescending(e => e.IDOrdemServico).ThenBy(e => e.Item).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Nro O.S.</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:left;\"><span>Item</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 30%; text-align:left;\"><span>Tipo Serviço</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 43%; text-align:left;\"><span>Observação</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Concluído?</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            foreach (var itemOS in listItensOS)
            {
                string concluidoStr = "NÃO";

                if (itemOS.Concluido)
                    concluidoStr = "SIM";

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemOS.IDOrdemServico.ToString("000000")}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:left;\">{itemOS.Item.ToString("000")}</td>";
                HTML += $"               <td style=\"width: 30%; text-align:left;\">{itemOS.TipoServico}</td>";
                HTML += $"               <td style=\"width: 43%; text-align:left;\">{itemOS.Observacao}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{concluidoStr}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            OrdemServicoPorTipoTemplate pvRelatorio = new OrdemServicoPorTipoTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                StatusFiltro = IDStatus.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDEmpresa == 0)
            {
                pvRelatorio.ClienteFiltro = "TODOS";
            }
            else
            {
                EmpresaEN empresa = _empresaRepository.GetByID(IDEmpresa);
                pvRelatorio.ClienteFiltro = empresa.RazaoSocial;
            }

            if (IDResp == 0)
            {
                pvRelatorio.ResponsavelFiltro = "TODOS";
            }
            else
            {
                ResponsavelEN responsavel = _responsavelRepository.GetByID(IDResp);
                pvRelatorio.ResponsavelFiltro = responsavel.NomeResponsavel;
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioOrdemServicoPorTipo.html";

            var documentoBase64 = _documentoService.GerarDocumento<OrdemServicoPorTipoTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string MovimentacaoFinanceiraContasReceberImprimir(string CaminhoTemplate, int IDEmpresa, OrigemContasReceberEnum IDOrigem, ContasReceberStatusEnum IDStatus, DateTime DataInicial, DateTime DataFinal)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                ctr.idcontasreceber     as Id,
                                ctr.idcontasreceber     as IDContasReceber,
                                ped.idpedido            as IDPedido,
                                ctr.datacadastro        as DataCadastro,
                                ctr.datavencimento      as DataVencimento,
                                ctr.numerotitulo        as NumeroTitulo,
                                ctr.seq                 as Parcela,
                                ctr.origem              as Origem,
                                ctr.status              as Status,
                                ctr.valor               as ValorTitulo,
                                ctr.valorpago           as ValorPago,
                                emp.razaosocial         as RazaoSocial
                              from tbcontasreceber ctr
                             inner join tbcadempresas emp on ctr.idempresa = emp.idempresa
                              left join tbpedidovenda ped on ctr.chave = ped.idpedido
                                                         and ctr.origem = 2
                             where ctr.idcompany = {idCompany}
                               and ctr.datavencimento between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDEmpresa != 0)
            {
                SQL += $" and ctr.idempresa = {IDEmpresa.ToString()}";
            }

            if (IDOrigem != 0)
            {
                SQL += $" and ctr.origem = {(int)IDOrigem}";
            }

            if (IDStatus != ContasReceberStatusEnum.Todos)
            {
                SQL += $" and ctr.status = {(int)IDStatus}";
            }

            var listContasReceber = _repositoryMovimentacaoFinanceiraContasReceber.FromSql(SQL).OrderByDescending(e => e.IDContasReceber).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 9%; text-align:left;\"><span>Nro Título</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Dt Criação</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Dt Vencto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 04%; text-align:center;\"><span>Parc</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 25%; text-align:left;\"><span>Cliente</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 13%; text-align:left;\"><span>Origem</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Ped</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 08%; text-align:left;\"><span>Status</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:right;\"><span>Vlr Título</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:right;\"><span>Vlr Pago</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            decimal valorTotalTitulos = 0;
            decimal valorTotalPagos = 0;

            foreach (var itemCR in listContasReceber)
            {
                valorTotalTitulos += itemCR.ValorTitulo;
                valorTotalPagos += itemCR.ValorPago;

                string numeroPedido = string.Empty;

                if (itemCR.Origem == OrigemContasReceberEnum.PedidoVenda)
                    numeroPedido = ((int)itemCR.IDPedido).ToString("000000");

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 9%; text-align:left;\">{itemCR.NumeroTitulo}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemCR.DataCadastro.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemCR.DataVencimento.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 04%; text-align:center;\">{itemCR.Parcela.ToString("000")}</td>";
                HTML += $"               <td style=\"width: 25%; text-align:left;\">{itemCR.RazaoSocial}</td>";
                HTML += $"               <td style=\"width: 13%; text-align:left;\">{itemCR.Origem.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{numeroPedido}</td>";
                HTML += $"               <td style=\"width: 08%; text-align:left;\">{itemCR.Status.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(itemCR.ValorTitulo, true)}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:right;\">{Sistema.Utils.Helper.FormatReal(itemCR.ValorPago, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr>";
            HTML += $"               <td style=\"width: 9%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 07%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 07%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 04%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 25%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 13%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 07%; text-align:left;\">&nbsp;</td>";
            HTML += $"               <td style=\"width: 08%; text-align:left;\"><strong>Totais:</strong></td>";
            HTML += $"               <td style=\"width: 10%; text-align:right;\"><strong>{Sistema.Utils.Helper.FormatReal(valorTotalTitulos, true)}</strong></td>";
            HTML += $"               <td style=\"width: 10%; text-align:right;\"><strong>{Sistema.Utils.Helper.FormatReal(valorTotalPagos, true)}</strong></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            //HTML += $"    <td style=\"text-align:right;\"><strong>Totais: {Sistema.Utils.Helper.FormatReal(valorTotalTitulos, true)}</strong></td>";
            //HTML += $"    <td style=\"text-align:right;\"><strong>Total Pagos: {Sistema.Utils.Helper.FormatReal(valorTotalPagos, true)}</strong></td>";
            HTML += $"</tr>";

            MovimentacaoFinanceiraContasReceberTemplate pvRelatorio = new MovimentacaoFinanceiraContasReceberTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                StatusFiltro = IDStatus.ToDescriptionEnum(),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDEmpresa == 0)
            {
                pvRelatorio.ClienteFiltro = "TODOS";
            }
            else
            {
                EmpresaEN empresa = _empresaRepository.GetByID(IDEmpresa);
                pvRelatorio.ClienteFiltro = empresa.RazaoSocial;
            }

            if (IDOrigem == 0)
            {
                pvRelatorio.OrigemFiltro = "TODOS";
            }
            else
            {
                pvRelatorio.OrigemFiltro = IDOrigem.ToDescriptionEnum();
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioMovimentacaoFinanceiraContasReceber.html";

            var documentoBase64 = _documentoService.GerarDocumento<MovimentacaoFinanceiraContasReceberTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        public string MovimentacaoFinanceiraFluxoCaixaImprimir(string CaminhoTemplate, TipoLancamentoFluxoCaixaEnum IDTipoLancamento, OrigemFluxoCaixaEnum IDOrigem, DateTime DataInicial, DateTime DataFinal, int IDEmpresa)
        {
            string dataInicialFiltro = $"{DataInicial.ToString("yyyy-MM-dd")} 00:00:00";
            string dataFinalFiltro = $"{DataFinal.ToString("yyyy-MM-dd")} 23:59:59";

            string SQL = $@"select
                                flc.idfluxocaixa        as Id,
                                flc.idfluxocaixa        as IDFluxoCaixa,
                                ped.idpedido            as IDPedido,
                                flc.datalancamento      as DataLancamento,
                                ctr.numerotitulo        as NumeroTitulo,
                                ctr.seq                 as Parcela,
                                emp.razaosocial         as RazaoSocial,
                                flc.tipolancamento      as TipoLancamento,
                                flc.origem              as Origem,
                                flc.observacao          as Observacao,
                                flc.valor               as Valor
                              from tbfluxocaixa flc
                              left join tbcontasreceber ctr on flc.chave = ctr.idcontasreceber
                                                           and ctr.origem = 2
                              left join tbcadempresas emp   on ctr.idempresa = emp.idempresa
                              left join tbpedidovenda ped   on ctr.chave = ped.idpedido
                                                           and ctr.origem = 2
                             where flc.idcompany = {idCompany}
                               and flc.datalancamento between '{dataInicialFiltro}' and '{dataFinalFiltro}'";

            if (IDTipoLancamento != 0)
            {
                SQL += $" and flc.tipolancamento = {(int)IDTipoLancamento}";
            }

            if (IDOrigem != 0)
            {
                SQL += $" and flc.origem = {(int)IDOrigem}";
            }

            if (IDEmpresa != 0 && IDOrigem == OrigemFluxoCaixaEnum.ContasReceber)
            {
                SQL += $" and ctr.idempresa = {IDEmpresa.ToString()}";
            }

            var listFluxoCaixa = _repositoryMovimentacaoFinanceiraFluxoCaixa.FromSql(SQL).OrderBy(e => e.IDFluxoCaixa).ToList();

            string HTML = "";

            HTML += $"<tr>";
            HTML += $"   <td>";
            HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
            HTML += $"           <tr style=\"background-color: #888888;color:#ffffff;\">";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Fluxo</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 09%; text-align:left;\"><span>Dt Lancto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 08%; text-align:left;\"><span>Tipo Lancto</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 13%; text-align:left;\"><span>Origem</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Título</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 05%; text-align:center;\"><span>Parc</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 15%; text-align:left;\"><span>Cliente</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 07%; text-align:left;\"><span>Nro Ped</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 15%; text-align:left;\"><span>Cliente</span></td>";
            HTML += $"               <td style=\"font-weight: bold; width: 10%; text-align:right;\"><span>Valor</span></td>";
            HTML += $"          </tr>";
            HTML += $"       </table>";
            HTML += $"   </td>";
            HTML += $"</tr>";

            decimal valorTotal = 0;
            string color = "";
            string colorFooter = "";

            foreach (var itemFC in listFluxoCaixa)
            {
                if (itemFC.TipoLancamento == TipoLancamentoFluxoCaixaEnum.Entrada)
                {
                    valorTotal += itemFC.Valor;
                    color = "blue";
                }
                else
                {
                    valorTotal -= itemFC.Valor;
                    color = "#E00500";
                }

                string numeroTitulo = string.Empty;
                string numeroParcela = string.Empty;
                string razaoSocial = string.Empty;
                string numeroPedido = string.Empty;

                if (itemFC.Origem == OrigemFluxoCaixaEnum.ContasReceber)
                {
                    numeroTitulo = itemFC.NumeroTitulo;
                    numeroParcela = ((int)itemFC.Parcela).ToString("000");
                    razaoSocial = itemFC.RazaoSocial;
                    numeroPedido = ((int)itemFC.IDPedido).ToString("000000");
                }

                HTML += $"<tr>";
                HTML += $"   <td>";
                HTML += $"       <table cellpadding=\"0\" cellspacing=\"0\">";
                HTML += $"           <tr>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{itemFC.IDFluxoCaixa.ToString("00000")}</td>";
                HTML += $"               <td style=\"width: 09%; text-align:left;\">{itemFC.DataLancamento.ToString("dd/MM/yyyy")}</td>";
                HTML += $"               <td style=\"width: 08%; text-align:left;\">{itemFC.TipoLancamento.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 13%; text-align:left;\">{itemFC.Origem.ToDescriptionEnum()}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{numeroTitulo}</td>";
                HTML += $"               <td style=\"width: 05%; text-align:center;\">{numeroParcela}</td>";
                HTML += $"               <td style=\"width: 15%; text-align:left;\">{razaoSocial}</td>";
                HTML += $"               <td style=\"width: 07%; text-align:left;\">{numeroPedido}</td>";
                HTML += $"               <td style=\"width: 15%; text-align:left;\">{itemFC.Observacao}</td>";
                HTML += $"               <td style=\"width: 10%; text-align:right; color:{color}\">{Sistema.Utils.Helper.FormatReal(itemFC.Valor, true)}</td>";
                HTML += $"          </tr>";
                HTML += $"       </table>";
                HTML += $"   </td>";
                HTML += $"</tr>";
            }

            HTML += $"<tr>";
            HTML += $"    <td style=\"padding-left:510px;\"><hr style=\"border: dashed 1px #6a6d73; width: 230px;\" /></td>";
            HTML += $"</tr>";

            if (valorTotal >= 0)
                colorFooter = "blue";
            else
                colorFooter = "#E00500";

            HTML += $"<tr>";
            HTML += $"    <td style=\"text-align:right; color:{colorFooter}\"><strong>Total: {Sistema.Utils.Helper.FormatReal(valorTotal, true)}</strong></td>";
            HTML += $"</tr>";

            MovimentacaoFinanceiraFluxoCaixaTemplate pvRelatorio = new MovimentacaoFinanceiraFluxoCaixaTemplate()
            {
                DataInclusao = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy"),
                HorarioInclusao = DateTime.Now.ToLocalTime().ToString("HH:mm:sss"),
                DataInicial = DataInicial.ToString("dd/MM/yyyy"),
                DataFinal = DataFinal.ToString("dd/MM/yyyy"),
                ConteudoRelatorio = HTML,
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            if (IDTipoLancamento == 0)
            {
                pvRelatorio.TipoLancamentoFiltro = "TODOS";
            }
            else
            {
                pvRelatorio.TipoLancamentoFiltro = IDTipoLancamento.ToDescriptionEnum();
            }

            if (IDOrigem == 0)
            {
                pvRelatorio.OrigemFiltro = "TODOS";
            }
            else
            {
                pvRelatorio.OrigemFiltro = IDOrigem.ToDescriptionEnum();
            }

            string caminhoBaseArquivo = CaminhoTemplate;
            string caminhoArquivoHTML = $"{CaminhoTemplate}RelatorioMovimentacaoFinanceiraFluxoCaixa.html";

            var documentoBase64 = _documentoService.GerarDocumento<MovimentacaoFinanceiraFluxoCaixaTemplate>(caminhoArquivoHTML, caminhoBaseArquivo, pvRelatorio);

            return documentoBase64;
        }

        #endregion Relatórios
    }
}
