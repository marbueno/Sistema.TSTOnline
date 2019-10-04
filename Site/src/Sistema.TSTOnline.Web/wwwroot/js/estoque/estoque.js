var codigo = 0;
var columns = [
    { "data": "codigo" },
    //{ "data": "sku" },
    { "data": "produtoNome" },
    { "data": "qtde" }
];

$(document).ready(function () {
    carregarEstoques().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblEstoque', listEstoques, columns);
        }
    });
});