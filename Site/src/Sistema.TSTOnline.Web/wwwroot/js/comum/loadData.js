var listVendedores = [];
var listFornecedores = [];
var listLocaisServicos = [];
var listTiposServicos = [];
var listCategorias = [];
var listSubCategorias = [];
var listProdutos = [];

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