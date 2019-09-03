/* CADASTROS */
var listEmpresas = [];
var listVendedores = [];
var listFornecedores = [];
var listLocaisServicos = [];
var listTiposServicos = [];
var listCategorias = [];
var listSubCategorias = [];
var listProdutos = [];
var listOrdemServicos = [];
var listOrdemServicoItens = [];
var listResponsaveis = [];
var listPedidosVenda = [];
var listPedidosVendaItens = [];
var listEstoques = [];
var listMovimentoEstoque = [];
var listContasReceber = [];
var listFluxoCaixa = [];

/* CADASTROS */
function carregarEmpresas() {

    return new Promise((resolve, reject) => {

        fetch('/cadastros/listEmpresas')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listEmpresas.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarVendedores () {

    return new Promise((resolve, reject) => {

        fetch('/cadastros/listVendedores')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listVendedores.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarFornecedores() {

    return new Promise((resolve, reject) => {

        fetch('/cadastros/listFornecedores')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listFornecedores.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarResponsaveis() {

    return new Promise((resolve, reject) => {

        fetch('/cadastros/listResponsaveis')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listResponsaveis.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

/* ORDEM DE SERVI�O */
function carregarLocaisServicos() {

    return new Promise((resolve, reject) => {

        fetch('/ordemservico/listLocaisServicos')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listLocaisServicos.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarTiposServicos() {

    return new Promise((resolve, reject) => {

        fetch('/ordemservico/listTiposServicos')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listTiposServicos.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarOrdemServicos() {

    return new Promise((resolve, reject) => {

        fetch('/ordemservico/listOrdemServicos')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listOrdemServicos.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarOrdemServicoItens(idOrdemServico) {
    
    if (idOrdemServico === null || idOrdemServico === undefined || idOrdemServico === "")
        idOrdemServico = 0;

    return new Promise((resolve, reject) => {

        fetch('/ordemservico/listOrdemServicoItens/' + idOrdemServico)
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listOrdemServicoItens.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

/* PRODUTOS */
function carregarCategorias() {

    return new Promise((resolve, reject) => {

        fetch('/produtos/listCategorias')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listCategorias.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarSubCategorias() {

    return new Promise((resolve, reject) => {

        fetch('/produtos/listSubCategorias')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listSubCategorias.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarProdutos() {

    return new Promise((resolve, reject) => {

        fetch('/produtos/listProdutos')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listProdutos.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

/* PEDIDO DE VENDA */
function carregarPedidosVenda() {

    return new Promise((resolve, reject) => {

        fetch('/pedidovenda/listPedidosVenda')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listPedidosVenda.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarPedidosVendaItens(idPedido) {

    if (idPedido === null || idPedido === undefined || idPedido === "")
        idPedido = 0;

    return new Promise((resolve, reject) => {

        fetch('/pedidovenda/listPedidosVendaItens/' + idPedido)
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listPedidosVendaItens.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

/* ESTOQUES */
function carregarEstoques() {

    return new Promise((resolve, reject) => {

        fetch('/estoque/listEstoques')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listEstoques.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarMovimentoEstoque() {

    return new Promise((resolve, reject) => {

        fetch('/estoque/listMovimentoEstoque')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listMovimentoEstoque.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

/* MOVIMENTA��O FINANCEIRA */
function carregarContasReceber() {

    return new Promise((resolve, reject) => {

        fetch('/movimentacaofinanceira/listContasReceber')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listContasReceber.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}

function carregarFluxoCaixa() {

    return new Promise((resolve, reject) => {

        fetch('/movimentacaofinanceira/listFluxoCaixa')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; listFluxoCaixa.push(item); iCount++; });
                resolve(true);
            })
            .catch(ex => {
                console.log(ex);
                reject(true);
            });
    });
}