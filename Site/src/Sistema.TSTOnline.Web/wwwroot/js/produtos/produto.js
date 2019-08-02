var codigo = 0;
var columns = [
    { "data": "codigo" },
    { "data": "sku" },
    { "data": "nome" },
    { "data": "fornecedorRazaoSocial" },
    { "data": "categoriaDescricao" },
    { "data": "preco" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {
            return "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.codigo + ")' title='Editar'>Editar</a>";
        }
    },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar' onclick='codigo=" + row.codigo + "' title='Excluir'>Excluir</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/produtos/produtoAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/produtos/produtoDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarProdutos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblProduto', listProdutos, columns);
        }
    });
});