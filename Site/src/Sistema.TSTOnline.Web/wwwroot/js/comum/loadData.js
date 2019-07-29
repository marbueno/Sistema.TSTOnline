var listVendedores = [];
var listFornecedores = [];

function carregarVendedores () {

    return new Promise((resolve, reject) => {

        fetch('/Cadastros/listVendedores')
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

        fetch('/Cadastros/listFornecedores')
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