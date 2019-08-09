/* CADASTROS */
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

/* CADASTROS */
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

/* ORDEM DE SERVIÇO */
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

function carregarOrdemServicoItens() {

    return new Promise((resolve, reject) => {

        fetch('/ordemservico/listOrdemServicoItens')
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