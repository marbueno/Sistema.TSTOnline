var codigo = 0;
var columns = [
    { "data": "codigo" },
    {
        "data": "dataMovimento",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "origemDescricao" },
    { "data": "sku" },
    { "data": "produtoNome" },
    { "data": "tipoDescricao" },
    { "data": "qtde" }
];

$(document).ready(function () {
    carregarMovimentoEstoque().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblMovimentoEstoque', listMovimentoEstoque, columns);
        }
    });
});