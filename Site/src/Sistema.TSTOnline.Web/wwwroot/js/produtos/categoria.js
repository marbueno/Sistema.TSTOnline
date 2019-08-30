var codigo = 0;
var columns = [
    { "data": "codigo" },
    { "data": "descricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {
            return "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.codigo + ")' title='Editar'>Editar</a>";
        }
    },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_0' onclick='codigo=" + row.codigo + "' title='Excluir'>Excluir</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/produtos/categoriaAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/produtos/categoriaDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarCategorias().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblCategoria', listCategorias, columns);
        }
    });
});