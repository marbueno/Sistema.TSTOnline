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

        private readonly IRepository<EmpresaEN> _empresaRepository;

        private readonly IRepository<LocalServicoEN> _localServicoRepository;

        private readonly IRepository<TipoServicoEN> _tipoServicoRepository;

        private readonly IRepository<ProdutoEN> _produtoRepository;

        private readonly IRepository<FluxoCaixaEN> _fluxoCaixaRepository;

        private readonly IRepository<ContasReceberEN> _contasReceberRepository;

        private readonly IRepository<VendasPorVendedorEN> _repositoryVendasPorVendedor;

        private readonly IRepository<VendasPorClienteEN> _repositoryVendasPorCliente;

        private readonly IDocumento _documentoService;

        private readonly UsuarioService _usuarioService;

        private int idCompany => _usuarioService.GetCompanyId();

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

                IRepository<VendasPorVendedorEN> repositoryVendasPorVendedor,

                IRepository<VendasPorClienteEN> repositoryVendasPorCliente,

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

            _empresaRepository = empresaRepository;

            _localServicoRepository = localServicoRepository;

            _tipoServicoRepository = tipoServicoRepository;

            _produtoRepository = produtoRepository;

            _fluxoCaixaRepository = fluxoCaixaRepository;

            _contasReceberRepository = contasReceberRepository;

            _repositoryVendasPorVendedor = repositoryVendasPorVendedor;

            _repositoryVendasPorCliente = repositoryVendasPorCliente;

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
                ClienteRazaoSocial = empresa.RazaoSocial,
                ClienteRazaoEnderecoCompleto = $"{empresa.Endereco}, {empresa.Numero} - {empresa.Bairro} - {empresa.Cidade}/{empresa.UF}",
                ClienteRazaoTelefoneCompleto = $"Fone: {empresa.Telefone}",
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
                PedidoFormaPagamento = pedidoVendaEN.TipoPagamento.ToDescriptionEnum(),
                PedidoQtdeParcelas = pedidoVendaEN.QtdeParcelas.ToDescriptionEnum(),
                PedidoValorParcela = Sistema.Utils.Helper.FormatReal(valorParcela, true),
                DataInclusaoPorExtenso = Sistema.Utils.Helper.DataPorExtenso(DateTime.Now.ToLocalTime()),
            };

            empresa = _empresaRepository.GetByID(vendedor.IDEmpresa);
            pvTemplate.VendedorEmpresa = empresa.RazaoSocial;
            pvTemplate.VendedorEmpresaCnpj = empresa.NrMatricula;
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

            foreach (var itemPedido in listPedidosVenda)
            {
                var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == itemPedido.IDPedido);
                decimal valorTotalPedido = listPedidoVendaItem.Sum(obj => obj.ValorTotal);

                if (idVendedor != itemPedido.IDVendedor)
                {
                    if (idVendedor != 0)
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

                idVendedor = itemPedido.IDVendedor;
            }
            
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

        #endregion Relatórios
    }
}
